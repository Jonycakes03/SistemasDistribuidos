from concurrent import futures
import grpc
import trainer_pb2
import trainer_pb2_grpc
from google.protobuf.timestamp_pb2 import Timestamp
from datetime import datetime
from pymongo import MongoClient
from Infrastructure.MongoDBSettings import get_settings
from Repositories.trainer_repository import TrainerRepository
from Services.trainer_service import TrainerService

def serve():
    settings = get_settings()

    client = MongoClient(settings.connection_string)
    db = client[settings.database_name]
    trainers_collection = db[settings.trainers_collection_name]

    trainer_repository = TrainerRepository(trainers_collection)
    trainer_service = TrainerService(trainer_repository)

    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    trainer_pb2_grpc.add_TrainerServiceServicer_to_server(trainer_service, server)
    server.add_insecure_port('[::]:50051')
    print("Servidor gRPC corriendo en el puerto 50051...")
    server.start()
    server.wait_for_termination()

if __name__ == '__main__':
    serve()
