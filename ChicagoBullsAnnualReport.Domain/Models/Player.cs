using Newtonsoft.Json;

namespace ChicagoBullsAnnualReport.Domain.Models
{
    public class Player : Person
    {
        [JsonProperty(Order = 2)]
        public string Position { get; set; }
        [JsonProperty(Order = 6)]
        public string Height { get; set; }
        [JsonProperty(Order = 6)]
        public string Weight { get; set; }
        [JsonProperty(Order = 9)]
        public double PPG { get; set; }
        [JsonProperty(Order = 3 )]
        public int Number { get; set; }
    }
}