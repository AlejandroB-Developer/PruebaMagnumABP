using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PruebaMagnumABP.Application.Interfaces.Services;

namespace PruebaMagnumABP.Application.Features.Game.Command
{
    public class CreateNewGameCommand : IRequest<int>
    {
        public int? GameId { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public int? WinnerId { get; set; }
        public bool IsFinished { get; set; }
    }

    public class CreateNewGameCommandHandler : IRequestHandler<CreateNewGameCommand, int>
    {
        private readonly ILogger<CreateNewGameCommandHandler> _logger;
        private readonly IGameService _gameService;

        public CreateNewGameCommandHandler(ILogger<CreateNewGameCommandHandler> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        public async Task<int> Handle(CreateNewGameCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("RegistrarPartidaCommandHandler started");

            try
            {
                if (!request.IsFinished)
                {
                    return await _gameService.RegisterNewGameAsync(request, cancellationToken);
                }
                else
                {
                    return await _gameService.UpdateExistingGameAsync(request, cancellationToken);
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error while saving the game.");
                throw new DbUpdateException("Error registering the game.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while processing the game.");
                throw new ApplicationException("Unexpected error while registering the game.", ex);
            }

        }
    }
}
