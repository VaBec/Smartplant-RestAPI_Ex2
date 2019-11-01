using SmartPlantREST.Controllers;
using System;
using System.Threading.Tasks;

namespace SmartPlantREST.Repositories
{
    public class PlantRepository
    {
        public PlantModel GetPlantbyID(string id)
        {
            var result = new PlantModel();

            result.PlantName = "Baum";
            result.GrownSize = 1.60;

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