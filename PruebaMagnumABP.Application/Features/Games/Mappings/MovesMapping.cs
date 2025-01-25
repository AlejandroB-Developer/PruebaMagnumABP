using AutoMapper;
using PruebaMagnumABP.Application.Features.Games.Dtos;
using PruebaMagnumABP.Domain.Entities;

namespace PruebaMagnumABP.Application.Features.Games.Mappings
{
    public class MovesMapping : Profile
    {
        public MovesMapping()
        {
            CreateMap<Move, MovesDto>().ReverseMap();
        }
    }
}
