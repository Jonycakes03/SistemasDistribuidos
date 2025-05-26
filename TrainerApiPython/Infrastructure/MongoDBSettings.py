import os
from dataclasses import dataclass

@dataclass
class MongoDBSettings:
    connection_string: str
    database_name: str
    trainers_collection_name: str

def get_settings():
    return MongoDBSettings(
        connection_string=os.getenv("MONGODB_CONNECTION_STRING", "mongodb://localhost:27017"),
        database_name=os.getenv("MONGODB_DATABASE_NAME", "TrainerDB"),
        trainers_collection_name=os.getenv("MONGODB_TRAINERS_COLLECTION_NAME", "trainers")
    )
