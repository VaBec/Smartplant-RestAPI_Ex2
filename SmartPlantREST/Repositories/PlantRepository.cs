using System;
using MongoDB.Bson;
using MongoDB.Driver;
using SmartPlantREST.Controllers;
using SmartPlantREST.DB;
using SmartPlantREST.Models;

namespace SmartPlantREST.Repositories
{
    public class PlantRepository
    {
        private IMongoDatabase plantDb;
        private IUserRepository userRepository;

        public PlantRepository(MongoDbContext db, UserRepository userRepository)
        {
            plantDb = db.GetPlantDb();
            this.userRepository = userRepository;
        }

        public RepositoryResult GetPlantsFromUser(string userName)
        {
            var result = new RepositoryResult();
            result.Successful = true;

            try
            {
                var plants = plantDb.GetCollection<PlantModel>("plant");
                var usersPlants = plants.Find(p => p.Owner == userName).ToList();
                foreach(PlantModel plant in usersPlants)
                {
                    var dt = plant.TimeStamp;
                    DateTime date = DateTime.Parse(dt);
                    DateTime newDate = new DateTime(date.Year, date.Month, date.Day, date.Hour + 1, date.Minute, date.Second);
                    plant.TimeStamp = newDate.ToString();
                }

                result.Payload = usersPlants;
            }
            catch(Exception e)
            {
                result.Successful = false;
                result.Payload = e.Message;
            }

            return result;
        }

        public RepositoryResult DeletePlant(RESTPlantDeleteModel plantModel)
        {
            var result = new RepositoryResult();

            try
            {
                var plants = plantDb.GetCollection<PlantModel>("plant");
                var plant = plants.Find(p => p.Id == plantModel.Id).FirstOrDefault();

                if(plant == null)
                {
                    result.Successful = false;
                    result.Payload = "Plant with ID " + plantModel.Id + " does not exist."; 
                }
                else
                {
                    if (plant.Owner == plantModel.Username)
                    {

                        var user = userRepository.GetUserByName(plantModel.Username);

                        if(user == null)
                        {
                            result.Successful = false;
                            result.Payload = "Could not find user: " + plantModel.Username;
                        }
                        else
                        {
                            if (user.Password == plantModel.Password)
                            {
                                result.Successful = true;
                                result.Payload = "Successfully deleted plant";
                                plants.DeleteOne(p => p.Id == plantModel.Id);
                            }
                            else
                            {
                                result.Successful = false;
                                result.Payload = "Wrong password!";
                            }
                        }
                    }
                    else
                    {
                        result.Successful = false;
                        result.Payload = "The user " + plantModel.Username + " does not own this plant.";
                    }
                }
            }
            catch (Exception e)
            {
                result.Successful = false;
                result.Payload = "Error while deleting plant: " + e.Message;
            }

            return result;
        }

        public RepositoryResult UpdatePlant(RESTPlantModel plantModel)
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