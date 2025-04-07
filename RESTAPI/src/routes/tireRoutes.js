import express from 'express';
import {
  getAllTires,
  getTiresById,
  createTires,
  updateTires,
  deleteTires,
  getPaginatedTires
} from '../services/tiresService.js';

const router = express.Router();

/**
 * @swagger
 * tags:
 *   name: Llantas
 *   description: Endpoints para gestión de llantas
 */

/**
 * @swagger
 * /api/resources/llantas:
 *   get:
 *     summary: Obtener todas las llantas
 *     tags: [Llantas]
 *     responses:
 *       200:
 *         description: Lista de llantas obtenida exitosamente
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 type: object
 */


router.get('/', async (req, res) => {
  try {
    const tires = await getAllTires();
    res.status(200).json(tires); 
  } catch (error) {
    res.status(500).json({ error: 'Failed to fetch tires' }); 
  }
});
/**
 * @swagger
 * /api/resources/llantas/{id}:
 *   get:
 *     summary: Obtener una llanta por ID
 *     tags: [Llantas]
 *     parameters:
 *       - in: path
 *         name: id
 *         required: true
 *         description: ID de la llanta
 *         schema:
 *           type: string
 *     responses:
 *       200:
 *         description: Llanta encontrada
 *       404:
 *         description: Llanta no encontrada
 */


router.get('/:id', async (req, res) => {
  try {
    const llanta = await getTiresById(req.params.id);
    if (!llanta) {
      return res.status(404).json({ error: 'Tire not found' }); // 404 Not Found
    }
    res.status(200).json(llanta);
  } catch (error) {
    res.status(500).json({ error: 'Failed to fetch tire' });
  }
});
/**
 * @swagger
 * /api/resources/llantas:
 *   post:
 *     summary: Crear una nueva llanta
 *     tags: [Llantas]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             required:
 *               - name
 *               - brand
 *               - size
 *             properties:
 *               name:
 *                 type: string
 *                 example: "All-Terrain"
 *               brand:
 *                 type: string
 *                 example: "Michelin"
 *               size:
 *                 type: string
 *                 example: "225/65R17" 
 *     responses:
 *       201:
 *         description: Llanta creada exitosamente
 *       400:
 *         description: Error al crear la llanta
 *       409:
 *         description: Llanta duplicada
 */

router.post('/', async (req, res) => {
  const { name, brand, size } = req.body;

  if (!name || !brand || !size) {
    return res.status(400).json({ message: 'Todos los campos son requeridos' });
  }

  try {
    const nuevaLlanta = await createTires({ name, brand, size });
    return res.status(201).json(nuevaLlanta);
  } catch (error) {
    if (error.code === 'P2002') {
      // Prisma: registro duplicado
      return res.status(409).json({ message: 'La llanta ya existe' });
    }
    return res.status(400).json({ message: 'Error al crear la llanta' });
  }
});
/**
 * @swagger
 * /api/resources/llantas/{id}:
 *   put:
 *     summary: Actualizar una llanta existente
 *     tags: [Llantas]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: string
 *         required: true
 *         description: ID de la llanta a actualizar
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             properties:
 *               name:
 *                 type: string
 *               brand:
 *                 type: string
 *               size:
 *                 type: string
 *     responses:
 *       200:
 *         description: Llanta actualizada exitosamente
 *       400:
 *         description: Error al actualizar
 *       404:
 *         description: Llanta no encontrada
 */

router.put('/:id', async (req, res) => {
  try {
    const updated = await updateTires(req.params.id, req.body);
    res.status(200).json(updated); 
  } catch (error) {
    res.status(400).json({ error: 'Failed to update tire' });
  }
});


/**
 * @swagger
 * /api/resources/llantas/{id}:
 *   delete:
 *     summary: Eliminar una llanta por ID
 *     tags: [Llantas]
 *     parameters:
 *       - in: path
 *         name: id
 *         required: true
 *         description: ID de la llanta a eliminar
 *         schema:
 *           type: string
 *     responses:
 *       204:
 *         description: Llanta eliminada correctamente
 *       400:
 *         description: Error al eliminar
 */


router.delete('/:id', async (req, res) => {
  try {
    await deleteTires(req.params.id);
    res.status(204).send(); 
  } catch (error) {
    res.status(400).json({ error: 'Failed to delete tire' });
  }
});

/**
 * @swagger
 * /api/resources/llantas:
 *   get:
 *     summary: Obtener una lista paginada de llantas
 *     tags: [Llantas]
 *     parameters:
 *       - in: query
 *         name: page
 *         schema:
 *           type: integer
 *           default: 1
 *         description: Número de página (por defecto es 1)
 *       - in: query
 *         name: size
 *         schema:
 *           type: integer
 *           default: 10
 *         description: Cantidad de resultados por página (por defecto es 10)
 *     responses:
 *       200:
 *         description: Lista de llantas paginada
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 data:
 *                   type: array
 *                   items:
 *                     type: object
 *                     properties:
 *                       id:
 *                         type: string
 *                       name:
 *                         type: string
 *                       brand:
 *                         type: string
 *                       size:
 *                         type: string
 *                 total:
 *                   type: integer
 *                 page:
 *                   type: integer
 *                 size:
 *                   type: integer
 *                 totalPages:
 *                   type: integer
 *       500:
 *         description: Error al obtener llantas paginadas
 */

router.get('/', async (req, res) => {
  const page = parseInt(req,Query,page) || 1;
  const size = parseInt(req.Query.size) || 10;

  try{
    const result = await getPaginatedTires(page, size);
    res.json(result);
  }catch(error){
    console.error('Error paginando las llantas: ', error);
    res.status(500).json({error: 'Error al obtener llantas paginadas'})
  }
})




export default router;
