using SmartPlantREST.Models;
using SmartPlantREST.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPlantREST.DB
{
    public interface IUserRepository
    {
        RepositoryResult LoginUser(RESTUserModel model);
        RepositoryResult Register(RESTUserModel model);
        RepositoryResult Update(RESTUserModel model);
        RepositoryResult Delete(string name);
        RepositoryResult GetUser(string name);
        RepositoryResult GetUsers();
    }
}
