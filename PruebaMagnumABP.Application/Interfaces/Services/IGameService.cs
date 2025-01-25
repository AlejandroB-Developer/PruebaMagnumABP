using PruebaMagnumABP.Application.Features.Game.Command;

namespace PruebaMagnumABP.Application.Interfaces.Services
{
    public interface IGameService
    {
        Task<int> RegisterNewGameAsync(CreateNewGameCommand request, CancellationToken cancellationToken);
        Task<int> UpdateExistingGameAsync(CreateNewGameCommand request, CancellationToken cancellationToken);
    }
}
