using Microsoft.EntityFrameworkCore;
using SmartPlantREST.Database.Tables;

namespace SmartPlantREST.Database
{
    public class DataBase : DbContext
    {
        public DbSet<Users> CardInformationForStudent { get; set; }

        public DataBase(DbContextOptions<DataBase> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server=localhost;database=library;user=user;password=password");
        }
    }
}
