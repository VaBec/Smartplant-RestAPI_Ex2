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

        public RepositoryResult DeleAllPlants()
        {
            var result = new RepositoryResult();

            result.Successful = true;
            result.Payload = "Successfully deleted all plants.";

            plantService.Get().ForEach(p => plantService.Remove(p));

            return result;
        }


        public RepositoryResult UpdatePlant(PlantModel model)
        {
            var result = new RepositoryResult();
            result.Successful = true;

            var tmp = plantService.GetPlantByMAC(model.MacAddress);

            if(tmp == null)
            {
                var plant = new Plant();

                plant.MAC = model.MacAddress;
                plant.Watervalue = model.Watervalue;
                plant.Id = ObjectId.GenerateNewId().ToString();

                plantService.Create(plant);

                result.Payload = "Created new plant.";
            }
            else
            {
                plantService.Update(tmp.Id, tmp);

                result.Payload = "Updated plant.";
            }

            return result;
        }
    }
}