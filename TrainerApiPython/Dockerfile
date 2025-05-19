FROM python:3.10-slim

WORKDIR /app

# Copia todos los archivos
COPY . .

# Instala dependencias requeridas
RUN pip install --no-cache-dir grpcio grpcio-tools protobuf pymongo

EXPOSE 50051

CMD ["python", "trainer_server.py"]
