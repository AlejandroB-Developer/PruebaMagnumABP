using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PruebaMagnumABP.Application.Interfaces.Contexts;
using Entity = PruebaMagnumABP.Domain.Entities;

namespace PruebaMagnumABP.Application.Features.Round.Command
{
    public class CreateNewRoundCommand : IRequest<bool>
    {
        public int GameId { get; set; }
        public int Player1Move { get; set; }
        public int Player2Move { get; set; }
        public string? Result { get; set; }
    }

    public class CreateNewRoundCommandHandler : IRequestHandler<CreateNewRoundCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<CreateNewRoundCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateNewRoundCommandHandler(IApplicationDbContext context, ILogger<CreateNewRoundCommandHandler> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateNewRoundCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("RegistrarRondaCommandHandler started");

            try
            {
                var newRound = _mapper.Map<Entity.Round>(request);

                await _context.Rounds.AddAsync(newRound, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al registrar la ronda.");
            }
            finally
            {
                _logger.LogDebug("RegistrarRondaCommandHandler finished successfully");
            }

            return false;
        }
    }
}
