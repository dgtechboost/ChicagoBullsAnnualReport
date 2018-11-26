using ChicagoBullsAnnualReport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChicagoBullsAnnualReport.Core
{
    /// <summary>
    /// Helper class for report
    /// </summary>
    public class ReportHelper : IReportHelper
    {

        public virtual List<Dictionary<string, string>> ContentProcessor(List<List<string>> list)
        {
            var listOfPlayers = new List<Dictionary<string, string>>();

            for (var i = 1; i < list.Count; i++)
            {
                listOfPlayers.Add(HeaderToContentMapper(list[0], list[i]));
            }

            return listOfPlayers;
        }
        public virtual List<Player> MapCSVDataToModel(List<Dictionary<string, string>> listOfPlayers)
        {
            var listOfMappedPlayers = new List<Player>();

            foreach (var playerDetails in listOfPlayers)
            {
                listOfMappedPlayers.Add(PlayerMapper(playerDetails));
            }

            return listOfMappedPlayers;
        }

        private Dictionary<string, string> HeaderToContentMapper(List<string> headerDetails, List<string> playerDetails)
        {
            var playerDictionary = new List<Dictionary<string, string>>();
            var dictionaryItem = new Dictionary<string, string>();

            if (headerDetails.Count == playerDetails.Count)
            {
                try
                {
                    for (int i = 0; i < headerDetails.Count; i++)
                    {
                        dictionaryItem.Add(headerDetails[i], playerDetails[i]);
                    }
                }
                catch (Exception ex)
                {
                    //log exception
                }
            }
            else
            {
                Console.WriteLine("There was an error processing this file");
            }

            return dictionaryItem;
        }

        private Player PlayerMapper(Dictionary<string, string> playerDetails)
        {
            var player = new Player()
            {
                Id = Convert.ToInt32(playerDetails.SingleOrDefault(s => s.Key == "Id").Value),
                Name = playerDetails.SingleOrDefault(s => s.Key == "Name").Value,
                Position = playerDetails.SingleOrDefault(s => s.Key == "Position").Value,
                Number = Convert.ToInt32(playerDetails.SingleOrDefault(s => s.Key == "Number").Value),
                Country = playerDetails.SingleOrDefault(s => s.Key == "Country").Value,
                Height = playerDetails.SingleOrDefault(s => s.Key == "Height").Value,
                Weight = playerDetails.SingleOrDefault(s => s.Key == "Weight").Value,
                University = playerDetails.SingleOrDefault(s => s.Key == "University").Value,
                PPG = Convert.ToDouble(playerDetails.SingleOrDefault(s => s.Key == "PPG").Value)
            };

            return player;
        }
    }
}
