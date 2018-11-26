using System.Collections.Generic;

namespace ChicagoBullsAnnualReport.Domain.Models
{
    public class Report 
    {
        public List<Player> SortedPlayers { get; set; }
        public string AveragePPG { get; set; }
        public List<object> Leaders { get; set; }
        public Dictionary<string, string> PlayersPositionCount { get; set; }
        public string AverageHeight { get; set; }
    }
}