using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartPlantREST.Repositories;

namespace SmartPlantREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantInfoController : ControllerBase
    {
        private PlantRepository plantRepository;

        public PlantInfoController(PlantRepository plantRepository)
        {
            this.plantRepository = plantRepository;
        }

        [HttpGet("/getplant")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PlantModel), (int) HttpStatusCode.OK)]
        public ActionResult<IEnumerable<string>> GetPlantByID(string id)
        {
            var result = plantRepository.GetPlantbyID(id);
            return this.Ok(result);
        }

        [HttpPut]
        public ActionResult<IEnumerable<string>> PutPlantData()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
