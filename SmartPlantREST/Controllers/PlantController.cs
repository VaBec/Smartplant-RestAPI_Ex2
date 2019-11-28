using System.Net;
using Microsoft.AspNetCore.Mvc;
using SmartPlantREST.Models;
using SmartPlantREST.Repositories;

namespace SmartPlantREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private PlantRepository plantRepository;

        public PlantController(PlantRepository plantRepository)
        {
            this.plantRepository = plantRepository;
        }

        [HttpPut("/updateplant")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RepositoryResult), (int)HttpStatusCode.OK)]
        public ActionResult UpdatePlant([FromBody] RESTPlantModel plantModel)
        {
            var result = plantRepository.UpdatePlant(plantModel);

            if (result.Successful)
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }

        [HttpDelete("/deleteplant")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RepositoryResult), (int)HttpStatusCode.OK)]
        public ActionResult DeletePlant([FromBody] RESTPlantDeleteModel plantModel)
        {
            var result = plantRepository.DeletePlant(plantModel);

            if (result.Successful)
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }

        [HttpGet("/plantsfromuser")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RepositoryResult), (int)HttpStatusCode.OK)]
        public ActionResult GetPlantsFromUser(string userName)
        {
            var result = plantRepository.GetPlantsFromUser(userName);

            if (result.Successful)
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }
    }
}
