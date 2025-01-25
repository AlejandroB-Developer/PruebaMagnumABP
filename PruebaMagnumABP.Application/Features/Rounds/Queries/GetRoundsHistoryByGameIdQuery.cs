using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PruebaMagnumABP.Application.Features.Rounds.Dtos;
using PruebaMagnumABP.Application.Interfaces.Contexts;

namespace PruebaMagnumABP.Application.Features.Round.Queries
{
    public class GetRoundsHistoryByGameIdQuery : IRequest<IEnumerable<RoundsDto>>
    {
        public int GameId { get; set; }
    }

    public class GetRoundsHistoryByGameIdQueryHandler : IRequestHandler<GetRoundsHistoryByGameIdQuery, IEnumerable<RoundsDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetRoundsHistoryByGameIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetRoundsHistoryByGameIdQueryHandler(IApplicationDbContext context, ILogger<GetRoundsHistoryByGameIdQueryHandler> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoundsDto>> Handle(GetRoundsHistoryByGameIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("GetRoundsHistoryByGameIdQueryHandler started");

            try
            {
                var rounds = await _context.Rounds
                    .Include(r => r.Player1Move)
                    .Include(r => r.Player2Move)
                    .Where(r => r.GameId == request.GameId)
                    .ToListAsync(cancellationToken);

                var result = _mapper.Map<IEnumerable<RoundsDto>>(rounds);

                _logger.LogDebug("GetRoundsHistoryByGameIdQueryHandler finished");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred when obtaining the round history.");
                throw new Exception("Unexpected error occurred when obtaining the round history.", ex);
            }
        }
    }
}

