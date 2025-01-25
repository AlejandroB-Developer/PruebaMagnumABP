using AutoMapper;
using PruebaMagnumABP.Application.Features.Player.Command;
using Entity = PruebaMagnumABP.Domain.Entities;

namespace PruebaMagnumABP.Application.Features.Players.Mappings
{
    public class PlayersMapping : Profile
    {
        public PlayersMapping()
        {
            CreateMap<CreateNewPlayerCommand, Entity.Player>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateTime.UtcNow.AddHours(-5)));
        }
    }
}
