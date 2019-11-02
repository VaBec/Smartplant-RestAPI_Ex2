using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPlantREST.PlantDB
{
    public class PlantDatabaseSettings : IPlantDatabaseSettings
    {
        public string PlantsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPlantDatabaseSettings
    {
        string PlantsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
