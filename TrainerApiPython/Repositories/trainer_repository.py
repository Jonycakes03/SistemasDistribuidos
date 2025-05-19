class TrainerRepository:
    def __init__(self, collection):
        self.collection = collection

    def get_trainer_by_id(self, trainer_id):
        return self.collection.find_one({"id": trainer_id})

    def insert_trainer(self, trainer_data):
        self.collection.insert_one(trainer_data)
