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

        [HttpPut("/updateplant")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RepositoryResult), (int)HttpStatusCode.OK)]
        public ActionResult UpdatePlant([FromBody] PlantModel plantModel)
        {
            var result = plantRepository.UpdatePlant(plantModel);

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

        [HttpDelete("/deleallplants")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RepositoryResult), (int)HttpStatusCode.OK)]
        public ActionResult DeleteAllPlants()
        {
            var result = plantRepository.DeleAllPlants();

            if (result.Successful)
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }

        [HttpGet("/getwatervalue")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RepositoryResult), (int)HttpStatusCode.OK)]
        public ActionResult GetWaterValueByMac([FromQuery] string macAddress)
        {
            var result = plantRepository.GetWaterValueByMacAddress(macAddress);

            if (result.Successful)
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }
    }
}
