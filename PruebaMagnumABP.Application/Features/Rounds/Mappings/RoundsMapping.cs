using AutoMapper;
using PruebaMagnumABP.Application.Features.Round.Command;
using PruebaMagnumABP.Application.Features.Rounds.Dtos;
using Entity = PruebaMagnumABP.Domain.Entities;

namespace PruebaMagnumABP.Application.Features.Rounds.Mappings
{
    public class RoundsMapping : Profile
    {
        public RoundsMapping()
        {
            CreateMap<CreateNewRoundCommand, Entity.Round>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.UtcNow.AddHours(-5)));

            CreateMap<Entity.Round, RoundsDto>()
                .ForMember(dest => dest.Player1Move, opt => opt.MapFrom(src => src.Player1Move.Name))
                .ForMember(dest => dest.Player2Move, opt => opt.MapFrom(src => src.Player2Move.Name));
        }
    }
}
