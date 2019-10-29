using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartPlantREST.Database.Tables
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public string name { get; set; }

        public string password { get; set; }
    }
}
