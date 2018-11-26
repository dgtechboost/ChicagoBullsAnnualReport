using AutoMapper;
using System.Collections.Generic;
using DomainModels = ChicagoBullsAnnualReport.Domain.Models;

namespace ChicagoBullsAnnualReport.Mapper
{
    public class ModelMapper : IModelMapper
    {
        private IMapper _mapper;

        public ModelMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<Models.Player> MapDomainModels(List<DomainModels.Player> players)
        {
            var mappedPlayers = new List<Models.Player>();

            foreach (var player in players)
            {
                var mappedPlayer = _mapper.Map<DomainModels.Player, Models.Player>(player);
                mappedPlayers.Add(mappedPlayer);
            }

            return mappedPlayers;
        }
    }
}