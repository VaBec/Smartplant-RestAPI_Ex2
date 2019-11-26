using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartPlantREST.DB;
using SmartPlantREST.Models;
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

        [HttpGet("/getallusers")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RepositoryResult), (int)HttpStatusCode.OK)]
        public ActionResult GetAllUsers()
        {
            var result = userRepostiroy.GetUsers();

            if (result.Successful)
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }

        [HttpPost("/login")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RepositoryResult), (int) HttpStatusCode.OK)]
        public ActionResult Login([FromBody] RESTUserModel model)
        {
            var result = userRepostiroy.LoginUser(model);

            if(result.Successful)
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }

        [HttpPut("/register")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RepositoryResult), (int) HttpStatusCode.OK)]
        public ActionResult RegisterUser([FromBody] RESTUserModel model)
        {
            var result = userRepostiroy.Register(model);

            if (result.Successful)
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }

        [HttpDelete("/deleteuser")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RepositoryResult), (int)HttpStatusCode.OK)]
        public ActionResult DeleteUser([FromBody] RESTUserModel model)
        {
            var result = userRepostiroy.Delete(model);

            if (result.Successful)
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }
    }
}
