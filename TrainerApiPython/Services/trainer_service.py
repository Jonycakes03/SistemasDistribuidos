import asyncio
import uuid
from datetime import datetime
from google.protobuf.timestamp_pb2 import Timestamp
import trainer_pb2
import trainer_pb2_grpc

class TrainerService(trainer_pb2_grpc.TrainerServiceServicer):
    def __init__(self, trainer_repository):
        self._trainer_repository = trainer_repository

    def GetTrainer(self, request, context):
        trainer_data = self._trainer_repository.get_trainer_by_id(request.id)

        if trainer_data is None:
            context.set_code(grpc.StatusCode.NOT_FOUND)
            context.set_details("Trainer not found")
            return trainer_pb2.TrainerResponse()

        birthdate = Timestamp()
        birthdate.FromDatetime(trainer_data.get("birthdate", datetime.utcnow()))
        created_at = Timestamp()
        created_at.FromDatetime(trainer_data.get("createdAt", datetime.utcnow()))

        medals = [
            trainer_pb2.Medals(region=m["region"], type=m["type"])
            for m in trainer_data.get("medals", [])
        ]

        return trainer_pb2.TrainerResponse(
            id=trainer_data["id"],
            name=trainer_data["name"],
            age=trainer_data["age"],
            birthdate=birthdate,
            medals=medals,
            createdAt=created_at
        )

    def CreateTrainer(self, request_iterator, context):
        count = 0
        created_trainers = []

        for request in request_iterator:
            trainer_id = str(uuid.uuid4())
            created_at = datetime.utcnow()

            trainer_doc = {
                "id": trainer_id,
                "name": request.name,
                "age": request.age,
                "birthdate": request.birthdate.ToDatetime(),
                "createdAt": created_at,
                "medals": [{"region": m.region, "type": m.type} for m in request.medals]
            }

            self._trainer_repository.insert_trainer(trainer_doc)

            
            pb_created_at = Timestamp()
            pb_created_at.FromDatetime(created_at)

            created_trainers.append(trainer_pb2.TrainerResponse(
                id=trainer_id,
                name=request.name,
                age=request.age,
                birthdate=request.birthdate,
                medals=request.medals,
                createdAt=pb_created_at
            ))
            count += 1

        return trainer_pb2.CreateTrainersResponse(
            success_count=count,
            trainers=created_trainers
        )

    def GetTrainersByName(self, request, context):
        if len(request.name) <= 1:
            context.set_code(grpc.StatusCode.INVALID_ARGUMENT)
            context.set_details("Name must be at least 2 characters long")
            return  

        trainers = self._trainer_repository.get_by_name(request.name)

        for trainer_data in trainers:
            birthdate = Timestamp()
            birthdate.FromDatetime(trainer_data.get("birthdate", datetime.utcnow()))

            created_at = Timestamp()
            created_at.FromDatetime(trainer_data.get("createdAt", datetime.utcnow()))

            medals = [
                trainer_pb2.Medals(region=m["region"], type=m["type"])
                for m in trainer_data.get("medals", [])
            ]

            yield trainer_pb2.TrainerResponse(
                id=trainer_data["id"],
                name=trainer_data["name"],
                age=trainer_data["age"],
                birthdate=birthdate,
                medals=medals,
                createdAt=created_at
            )

            # Simula el delay de 5 segundos como en C# (bloqueante aquí)
            asyncio.run(asyncio.sleep(5))