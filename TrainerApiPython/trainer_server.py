# trainer_server.py

from concurrent import futures
import grpc
import trainer_pb2
import trainer_pb2_grpc
from google.protobuf.timestamp_pb2 import Timestamp
import datetime
import uuid

class TrainerService(trainer_pb2_grpc.TrainerServiceServicer):
    def GetTrainer(self, request, context):
        
        now = datetime.datetime.now(datetime.timezone.utc)
        timestamp_now = Timestamp()
        timestamp_now.FromDatetime(now)

        return trainer_pb2.TrainerResponse(
            id=str(uuid.uuid4()),
            name="Johnatan Josue Suarez",
            age=22,
            birthdate=timestamp_now,
            medals=[
                trainer_pb2.Medals(region="MX", type=trainer_pb2.MedalType.GOLD),
                trainer_pb2.Medals(region="JPN", type=trainer_pb2.MedalType.SILVER)
            ],
            createdAt=timestamp_now
        )

def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    trainer_pb2_grpc.add_TrainerServiceServicer_to_server(TrainerService(), server)
    server.add_insecure_port('[::]:50051')
    print("Servidor gRPC corriendo en el puerto 50051...")
    server.start()
    server.wait_for_termination()

if __name__ == '__main__':
    serve()
