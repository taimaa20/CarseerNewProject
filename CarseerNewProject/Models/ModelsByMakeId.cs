namespace CarseerNewProject.Models
{
    public class ModelsByMakeId
    {
        public long Count { get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public List<CarDetails> Results { get; set; }

    }
    public class CarDetails
    {
        public long Make_ID { get; set; }
        public string Make_Name { get; set; }
        public string Model_ID { get; set; }
        public string Model_Name { get; set; }

    }
}
