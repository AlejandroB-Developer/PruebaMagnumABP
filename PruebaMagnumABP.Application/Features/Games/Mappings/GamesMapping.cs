using AutoMapper;
using PruebaMagnumABP.Application.Features.Game.Command;
using Entity = PruebaMagnumABP.Domain.Entities;

namespace PruebaMagnumABP.Application.Features.Games.Mappings
{
    public class GamesMapping : Profile
    {
        public GamesMapping()
        {
            CreateMap<CreateNewGameCommand, Entity.Game>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateTime.UtcNow.AddHours(-5)))
                .ForMember(dest => dest.WinnerId, opt => opt.MapFrom(src => src.WinnerId == 0 ? (int?)null : src.WinnerId))
                .ForMember(dest => dest.EndDate, opt => opt.Ignore());
        }
    }
}
