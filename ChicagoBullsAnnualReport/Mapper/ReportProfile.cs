using AutoMapper;
using DomainModels = ChicagoBullsAnnualReport.Domain.Models;

namespace ChicagoBullsAnnualReport.Mapper
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<DomainModels.Player, Models.Player>();
        }
    }
}