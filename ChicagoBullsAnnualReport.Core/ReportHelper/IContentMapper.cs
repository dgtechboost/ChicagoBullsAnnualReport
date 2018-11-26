using System.Collections.Generic;
using ChicagoBullsAnnualReport.Domain.Models;

namespace ChicagoBullsAnnualReport.Core
{
    public interface IContentMapper
    {
        List<Player> MapCSVDataToModel(List<Dictionary<string, string>> list);
    }
}
