using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPlantREST.PlantDB
{
    public class PlantService
    {
        private readonly IMongoCollection<Plant> _plants;

        public PlantService(IPlantDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _plants = database.GetCollection<Plant>(settings.PlantsCollectionName);
        }

        public Plant GetPlantByMAC(string macAddress) =>
            _plants.Find<Plant>(plant => plant.MAC == macAddress).FirstOrDefault();
        

        public List<Plant> Get() =>
            _plants.Find(plant => true).ToList();

        public Plant Get(string id) =>
            _plants.Find<Plant>(plant => plant.Id == id).FirstOrDefault();

        public Plant Create(Plant plant)
        {
            _plants.InsertOne(plant);
            return plant;
        }

        public void Update(Plant newPlant, Plant oldPlant)
        {
            Remove(oldPlant);
            Create(newPlant);
        }

        
        public void Update(string id, Plant plantIn) =>
            _plants.ReplaceOne(plant => plant.Id == id, plantIn);
        

        public void Remove(Plant plantIn) =>
            _plants.DeleteOne(plant => plant.Id == plantIn.Id);

        public void Remove(string id) =>
            _plants.DeleteOne(plant => plant.Id == id);
    }
}
