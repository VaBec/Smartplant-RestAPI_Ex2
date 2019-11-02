using System;
using MongoDB.Bson;
using SmartPlantREST.Controllers;
using SmartPlantREST.PlantDB;

namespace SmartPlantREST.Repositories
{
    public class PlantRepository
    {
        private PlantService plantService;

        public PlantRepository(PlantService plantService)
        {
            this.plantService = plantService;
        }

        public PlantModel GetPlantbyMAC(string mac)
        {
            var result = new PlantModel();

            return result;
        }

        public RepositoryResult GetAllPlants()
        {
            var result = new RepositoryResult();

            result.Successful = true;
            result.Payload = plantService.Get();

            return result;
        }


        public RepositoryResult AddPlant(PlantModel model)
        {
            var result = new RepositoryResult();

            var plant = new Plant();
            plant.MAC = model.MacAddress;
            plant.UserName = model.UserName;
            plant.Id = ObjectId.GenerateNewId().ToString();

            plantService.Create(plant);

            return result;
        }

        public RepositoryResult AddPlantData(long val)
        {
            var result = new RepositoryResult();

            result.Payload = "Added value: '" + val + "'";
            result.Successful = true;

            return result;
        }
    }
}