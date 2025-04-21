Como levantar el entorno
BASE DE DATOS:
Descargar imagen de postgres
ejecutar linea:
docker run --name postgres-db -e POSTGRES_USER=root -e POSTGRES_PASSWORD=admin -p 5432:5432 -d postgres
docker network connect app-network postgres-db, esto es despues de crear la red app-network en la api

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
POST (protegido)	/api/resources/llantas	        Crear una nueva llanta                  Respuestas: 201, 400, 409
PUT	    /api/resources/llantas/:id	    Actualizar una llanta                   Respuestas: 200, 404, 400
DELETE	/api/resources/llantas/:id	    Eliminar una llanta                     Respuestas: 204, 400

La API usa autenticación basada en tokens JWT (JSON Web Tokens) para proteger ciertos endpoints como la creación, modificación y eliminación de llantas. Este mecanismo garantiza que solo usuarios autenticados puedan realizar estas acciones.

POST /api/auth/login, se envia con el body: 
{
  "email": "admin@llantas.com",
  "password": "admin123"
}

y regresa un token de authenticacion, con este token podemos ejecutar alguna ruta protegida, en este caso protegimos la ruta de post 
para usarlo, haces el request del post y en los headers agregas la llave de autorizacion seguido del valor Bearer y el token 