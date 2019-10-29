using SmartPlantREST.Controllers;
using System;
using System.Threading.Tasks;

namespace SmartPlantREST.Repositories
{
    public class UserRepository
    {
        public RepositoryResult Register(UserModel model)
        {
            var result = new RepositoryResult();

            if (model.Username.ToLower() == "root")
            {
                result.Successful = true;
                result.Payload = "Registered successfully.";
            }
            else
            {
                result.Successful = false;
                result.Payload = "Error while registering.";
            }

            return result;
        }

        public RepositoryResult Login(UserModel model)
        {
            var result = new RepositoryResult();

            if (model.Username.ToLower() == "root")
            {
                result.Successful = true;
                result.Payload = "Logged in successfully.";
            }
            else
            {
                result.Successful = false;
                result.Payload = "User '" + model.Username + "' does not exist.";
            }

            return result;
        }

        public RepositoryResult AddUser(UserModel model)
        {
            var result = new RepositoryResult();

            if (model.Username.ToLower() == "root")
            {
                result.Successful = true;
                result.Payload = "Logged in successfully.";
            }
            else
            {
                result.Successful = false;
                result.Payload = "User '" + model.Username + "' does not exist.";
            }

            return result;
        }
    }
}