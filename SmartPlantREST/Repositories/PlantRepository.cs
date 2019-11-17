using System;
using MongoDB.Bson;
using MongoDB.Driver;
using SmartPlantREST.Controllers;
using SmartPlantREST.DB;

namespace SmartPlantREST.Repositories
{
    public class PlantRepository
    {
        private IMongoDatabase plantDb;

        public PlantRepository(MongoDbContext db)
        {
            plantDb = db.GetPlantDb();
        }

        public RepositoryResult UpdatePlant(RESTPlantUpdateModel plantModel)
        {
            var result = new RepositoryResult();

            try
            {
                var plants = plantDb.GetCollection<PlantModel>("plant");
                var plant = plants.Find(p => p.MacAddress == plantModel.MacAddress).FirstOrDefault();

                if (plant == null)
                {
                    var newPlant = new PlantModel();
                    newPlant.Id = ObjectId.GenerateNewId().ToString();
                    newPlant.MacAddress = plantModel.MacAddress;
                    newPlant.Owner = plantModel.Owner;
                    newPlant.Watervalue = plantModel.WaterValue;
                    newPlant.PlantType = (int)plantModel.PlantType;
                    newPlant.TimeStamp = DateTime.Now.ToString();

                    plants.InsertOne(newPlant);
                }
                else
                {
                    var newPlant = new PlantModel();
                    newPlant.Id = ObjectId.GenerateNewId().ToString();
                    newPlant.MacAddress = plantModel.MacAddress;
                    newPlant.Owner = plantModel.Owner;
                    newPlant.Watervalue = plantModel.WaterValue;
                    newPlant.PlantType = (int)plantModel.PlantType;
                    newPlant.TimeStamp = DateTime.Now.ToString();

                    plants.DeleteOne(p => p.MacAddress == plantModel.MacAddress);
                    plants.InsertOne(newPlant);
                }

                result.Successful = true;
                result.Payload = "Successfully updated plant.";
            }
            catch (Exception e)
            {
                result.Successful = false;
                result.Payload = e.Message;
            }
            return result;
        }
    }
}