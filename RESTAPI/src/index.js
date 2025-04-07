import express from 'express';
import cors from 'cors';
import dotenv from 'dotenv';
import {swaggerUi, swaggerSpec} from './config/swagger.js';


import llantasRoutes from './routes/tireRoutes.js';

import errorHandler from './middlewares/errorHandler.js';

dotenv.config();

const app = express();
const port = 5000;

//middlewares
app.use(cors());
app.use(express.json());

//swagger
app.use('/api-docs', swaggerUi.serve, swaggerUi.setup(swaggerSpec));


//ruta
app.use('/api/resources/llantas', llantasRoutes);
app.use(errorHandler);

app.listen(port, () => console.log(`Server running on port : http://localhost:${port}`));
