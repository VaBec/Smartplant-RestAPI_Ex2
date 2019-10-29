using Microsoft.AspNetCore.Mvc;
using SmartPlantREST.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPlantREST.Repositories
{
    public class RepositoryResult
    {

        public object Payload { get; set; }

        public bool Successful { get; set; }
    }
}