using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MongoDB.Driver;

namespace SmartPlantREST.DB
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase plantDb;

        public MongoDbContext()
        {
            var client = new MongoClient("mongodb+srv://Momo:momo1995@cluster0-9e7ww.mongodb.net/test?retryWrites=true&w=majority");
            plantDb = client.GetDatabase("plant_db");
        }

        public IMongoDatabase GetPlantDb()
        {
            return plantDb;
        }
    }
}  