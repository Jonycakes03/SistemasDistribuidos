

import grpc
import trainer_pb2
import trainer_pb2_grpc

def run():
    
    channel = grpc.insecure_channel('localhost:50051')
    stub = trainer_pb2_grpc.TrainerServiceStub(channel)

    request = trainer_pb2.TrainerByIdRequest(id="1")
    response = stub.GetTrainer(request)

    print("Respuesta del servidor:")
    print(f"ID: {response.id}")
    print(f"Nombre: {response.name}")
    print(f"Edad: {response.age}")
    print(f"Fecha de nacimiento: {response.birthdate.ToDatetime()}")
    print(f"Creado en: {response.createdAt.ToDatetime()}")
    for medal in response.medals:
        print(f"Medalla - Región: {medal.region}, Tipo: {medal.type}")

if __name__ == '__main__':
    run()
