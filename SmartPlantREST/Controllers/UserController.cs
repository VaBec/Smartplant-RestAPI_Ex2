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
    public class UserController : ControllerBase
    {
        private UserRepository userRepostiroy;

        public UserController(UserRepository userRepostiroy)
        {
            this.userRepostiroy = userRepostiroy;
        }

        [HttpPost("/register")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), (int) HttpStatusCode.OK)]
        public ActionResult<IEnumerable<string>> Register(UserModel model)
        {
            var result = userRepostiroy.Register(model);

            if (result.Successful)
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }

        [HttpPost("/login")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RepositoryResult), (int) HttpStatusCode.OK)]
        public ActionResult Login([FromBody] UserModel model)
        {
            var result = userRepostiroy.Login(model);

            if(result.Successful)
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }

        [HttpPut("/adduser")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RepositoryResult), (int) HttpStatusCode.OK)]
        public ActionResult Add([FromBody] UserModel model)
        {
            var result = userRepostiroy.AddUser(model);

            if (result.Successful)
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }
    }
}
