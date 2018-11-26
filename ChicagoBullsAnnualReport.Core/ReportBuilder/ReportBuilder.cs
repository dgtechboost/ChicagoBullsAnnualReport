using ChicagoBullsAnnualReport.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChicagoBullsAnnualReport.Core
{
    /// <summary>
    /// Builds a report and populates it into json file
    /// </summary>
    public class ReportBuilder : IReportBuilder
    {
        public void BuildReport(List<Player> mapPlayers)
        {
            var sortedPlayers = SortPlayersBasedOnPPGDesc(mapPlayers);
            var averagePointTeamPPG = CalculateAveragePointTeamPPG(mapPlayers);
            var playersStatuses = FindPlayersStatuses(mapPlayers);
            var playersPositionCount = CountPlayersEachPosition(mapPlayers);
            var averageHeight = CalculateAverageHeight(mapPlayers);

            var rep = new Report();

            var report = new Report()
            {
                SortedPlayers = sortedPlayers.Any() ? sortedPlayers : new List<Player>(),
                AveragePPG = !string.IsNullOrEmpty(averagePointTeamPPG) ? averagePointTeamPPG : "0",
                Leaders = playersStatuses.Any() ? playersStatuses : new List<object>(),
                PlayersPositionCount = playersPositionCount.Any() ? playersPositionCount : new Dictionary<string, string>(),
                AverageHeight = !string.IsNullOrEmpty(averageHeight) ? averageHeight : "0cm"
            };

            ConvertDataToJson(report);
        }

        private void ConvertDataToJson(Report reportData)
        {
            var json = JsonConvert.SerializeObject(reportData, Formatting.Indented);
            var pathToJsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Artefacts\", "chicago-bulls.json");
            File.WriteAllText(pathToJsonFile, json);
        }


        private string CalculateAveragePointTeamPPG(List<Player> mapPlayers)
        {
            var playersPPG = new List<double>();

            foreach (var player in mapPlayers)
            {
                playersPPG.Add(player.PPG);
            }

            return CalculateAverage(playersPPG);
        }

        private string CalculateAverage(List<double> valuesToCalculate)
        {
            return (Math.Round(valuesToCalculate.Sum() / valuesToCalculate.Count, 2)).ToString();
        }

        private string CalculateAverageHeight(List<Player> mapPlayers)
        {
            var averageHeightCentimetres = string.Empty;

            var feet = 0;
            var inches = 0;
            var cmPerGroupOfPlayer = new List<double>();
            var cmOfFeet = 0.0;
            var cmOfInches = 0.0;
            var totalCmPerPlayer = 0.0;

            foreach (var player in mapPlayers)
            {
                feet = Convert.ToInt32(player.Height.Substring(0, player.Height.IndexOf("ft")).ToString());
                inches = Convert.ToInt32(player.Height.Substring(player.Height.IndexOf("ft ") + " in".Length, player.Height.LastIndexOf("in") - (player.Height.IndexOf("ft ") + " in".Length)).Trim());

                cmOfFeet = feet * 30.48;
                cmOfInches = inches * 2.54;
                totalCmPerPlayer = cmOfFeet + cmOfInches;
                cmPerGroupOfPlayer.Add(totalCmPerPlayer);
            }

            return cmPerGroupOfPlayer.Average() + " cm";
        }

        private Dictionary<string, string> CountPlayersEachPosition(List<Player> mapPlayers)
        {
            var positionPlayersCount = new Dictionary<string, string>();
            var groupedByPosition = mapPlayers.GroupBy(x => x.Position).ToList();

            foreach (var group in groupedByPosition)
            {
                positionPlayersCount.Add(group.Key, group.Count(t=>t.Id > 0).ToString());
            }

            return positionPlayersCount;
        }

        private List<object> FindPlayersStatuses(List<Player> mapPlayers)
        {
            var sortedPlayers = SortPlayersBasedOnPPGDesc(mapPlayers);
            var leaderList = new List<object>();

            for (int i = 0; i < 3; i++)
            {
                var leader = CreateLeader.GetLeader(i, sortedPlayers[i]);
                leaderList.Add(leader);
            }

            return leaderList;
        }

        public static class CreateLeader
        {
            public static object GetLeader(int position, Player player)
            {
                switch (position)
                {
                    case 0:
                        return new GoldLeader() {Gold = player.Name, PPG = player.PPG };
                    case 1:
                        return new SilverLeader() { Silver = player.Name, PPG = player.PPG };
                    case 2:
                        return new BronzeLeader() { Bronze = player.Name, PPG = player.PPG };
                    default: return new GoldLeader() { Gold = string.Empty, PPG = 0.0 };
                }
            }
        }

        private List<Player> SortPlayersBasedOnPPGDesc(List<Player> mapPlayers)
        {
            return mapPlayers.OrderByDescending(t => t.PPG).ToList();
        }
    }
}
