using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PruebaMagnumABP.Application.Features.Game.Command;
using PruebaMagnumABP.Application.Interfaces.Contexts;
using PruebaMagnumABP.Application.Interfaces.Services;
using PruebaMagnumABP.Domain.Entities;

namespace PruebaMagnumABP.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GameService> _logger;

        public GameService(IApplicationDbContext context, IMapper mapper, ILogger<GameService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> RegisterNewGameAsync(CreateNewGameCommand request, CancellationToken cancellationToken)
        {
            var newGame = _mapper.Map<Game>(request);
            await _context.Games.AddAsync(newGame, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogDebug("New game registered successfully.");
            return newGame.Id;
        }

        public async Task<int> UpdateExistingGameAsync(CreateNewGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == request.GameId, cancellationToken);

            if (game == null)
            {
                _logger.LogWarning("Game not found for the provided ID.");
                throw new ArgumentException("Game not found.", nameof(request.GameId));
            }

            game.WinnerId = request.WinnerId;
            game.EndDate = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogDebug("Existing game updated successfully.");
            return game.Id;
        }
    }
}
