using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PruebaMagnumABP.Application.Features.Games.Dtos;
using PruebaMagnumABP.Application.Interfaces.Contexts;

namespace PruebaMagnumABP.Application.Features.Game.Queries
{
    public class GetMovesQuery : IRequest<IEnumerable<MovesDto>>{}

    public class GetMovesQueryHandler : IRequestHandler<GetMovesQuery, IEnumerable<MovesDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetMovesQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetMovesQueryHandler(IApplicationDbContext context, ILogger<GetMovesQueryHandler> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovesDto>> Handle(GetMovesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("GetMovesQueryHandler started");

            try
            {
                var moves = await _context.Moves.ToListAsync(cancellationToken);
                if (moves == null || !moves.Any())
                {
                    _logger.LogWarning("Not moves found.");
                    return Enumerable.Empty<MovesDto>();
                }

                var movesDto = _mapper.Map<IEnumerable<MovesDto>>(moves);
                _logger.LogDebug("GetMovesQueryHandler finished");

                return movesDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred when obtaining the moves.");
                throw new Exception("An unexpected error occurred when obtaining the moves.", ex);
            }
        }
    }

}
