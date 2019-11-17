namespace SmartPlantREST.Controllers
{
    public class RESTPlantUpdateModel
    {
        public string MacAddress { get; set; }

        public int WaterValue { get; set; }

        public string Owner { get; set; }

        public Models.PlantTypes.PlantType PlantType { get; set; }
    }
}