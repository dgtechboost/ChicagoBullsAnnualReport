using System.Collections.Generic;
using ChicagoBullsAnnualReport.Models;
using DomainModels = ChicagoBullsAnnualReport.Domain.Models;

namespace ChicagoBullsAnnualReport.Mapper
{
    public interface IModelMapper
    {
        List<Player> MapDomainModels(List<DomainModels.Player> players);
    }
}
