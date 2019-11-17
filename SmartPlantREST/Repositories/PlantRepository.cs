using System;
using MongoDB.Bson;
using SmartPlantREST.Controllers;

namespace SmartPlantREST.Repositories
{
    public class PlantRepository
    {
        public PlantRepository()
        {
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
            //result.Payload = plantService.Get();

            return result;
        }

        public RepositoryResult DeleAllPlants()
        {
            var result = new RepositoryResult();

            result.Successful = true;
            result.Payload = "Successfully deleted all plants.";

            //plantService.Get().ForEach(p => plantService.Remove(p));

            return result;
        }


        public RepositoryResult UpdatePlant(PlantModel model)
        {
            var result = new RepositoryResult();
            
            result.Successful = true;

            /*
            var oldPlant = plantService.GetPlantByMAC(model.MacAddress);

            var plant = new Plant();

            plant.MAC = model.MacAddress;
            plant.Watervalue = model.WaterValue;
            plant.Id = ObjectId.GenerateNewId().ToString();

            if (oldPlant == null)
            {
                plantService.Create(plant);

                result.Payload = "Created new plant with watervalue: '" + plant.Watervalue + "'.";
            }
            else
            {
                plantService.Update(plant, oldPlant);

                result.Payload = "Updated plant to watervalue: '" + plant.Watervalue + "'.";
            }
            */
            return result;
        }

        public RepositoryResult GetWaterValueByMacAddress(string macAddress)
        {
            var result = new RepositoryResult();

            /*
            var plant = plantService.GetPlantByMAC(macAddress);

            if(plant == null)
            {
                result.Successful = false;
                result.Payload = "Plant with macaddress '" + macAddress + "' does not exist.";
            } else
            {
                result.Successful = true;
                result.Payload = plant.Watervalue;
            }
            */
            return result;
        }
    }
}