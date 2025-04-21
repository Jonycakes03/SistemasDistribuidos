Como levantar el entorno
BASE DE DATOS:
Descargar imagen de postgres
ejecutar linea:
docker run --name postgres-db -e POSTGRES_USER=root -e POSTGRES_PASSWORD=admin -p 5432:5432 -d postgres
docker network connect app-network postgres-db

para levantar api:
ejecutar lineas
docker build -t llantas-api .
 docker run -d --name api-llantas --network app-network -p 5000:5000 --env-file .env llantas-api12

para probar los endpoints ir a url
localhost://5000/api-docs  ->swagger

localhost:5000/api/resources/llantas ->postman
Método	Endpoint	                    Descripción
GET	    /api/resources/llantas	        Obtener todas las llantas paginadas     Respuestas: 200, 500
GET	    /api/resources/llantas/:id	    Obtener una llanta por ID               Respuestas: 200, 404
POST	/api/resources/llantas	        Crear una nueva llanta                  Respuestas: 201, 400, 409
PUT	    /api/resources/llantas/:id	    Actualizar una llanta                   Respuestas: 200, 404, 400
DELETE	/api/resources/llantas/:id	    Eliminar una llanta                     Respuestas: 204, 400