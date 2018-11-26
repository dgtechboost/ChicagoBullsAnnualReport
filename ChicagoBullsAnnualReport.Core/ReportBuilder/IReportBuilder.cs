using ChicagoBullsAnnualReport.Domain.Models;
using System.Collections.Generic;

namespace ChicagoBullsAnnualReport.Core
{
    public interface IReportBuilder
    {
        void BuildReport(List<Player> mapPlayers);
    }
}
