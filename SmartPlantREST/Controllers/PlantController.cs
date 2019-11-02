using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPut("/addplant")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RepositoryResult), (int)HttpStatusCode.OK)]
        public ActionResult AddPlant([FromBody] int val)
        {
            var result = plantRepository.AddPlantData(val);

            if (result.Successful)
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }

        [HttpGet("/getallplants")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RepositoryResult), (int)HttpStatusCode.OK)]
        public ActionResult GetAllPlants()
        {
            var result = plantRepository.GetAllPlants();

            if (result.Successful)
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }
    }
}
