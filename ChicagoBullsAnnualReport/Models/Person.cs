using Newtonsoft.Json;

namespace ChicagoBullsAnnualReport.Models
{
    public class Person
    {

       [JsonProperty(Order = 1)]
        public int Id { get; set; }
        [JsonProperty(Order = 4)]
        public string Country { get; set; }
        [JsonProperty(Order = 8)]
        public string University { get; set; }
        [JsonProperty(Order = 5)]
        public string Name { get; set; }
    }
}