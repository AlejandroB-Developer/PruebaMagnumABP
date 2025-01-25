using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PruebaMagnumABP.Application.Interfaces.Contexts;
using Entity = PruebaMagnumABP.Domain.Entities;

namespace PruebaMagnumABP.Application.Features.Player.Command
{
    public class CreateNewPlayerCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
    public class CreateNewPlayerCommandHandler : IRequestHandler<CreateNewPlayerCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<CreateNewPlayerCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateNewPlayerCommandHandler(IApplicationDbContext context, ILogger<CreateNewPlayerCommandHandler> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateNewPlayerCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("CreateNewPlayerCommandHandler Started.");

            try
            {
                if (string.IsNullOrEmpty(request.Name))
                {
                    _logger.LogWarning("Debes ingresar un nombre de jugador para coontinuar.");
                }

                var newPlayer = _mapper.Map<Entity.Player>(request);

                await _context.Players.AddAsync(newPlayer, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                _logger.LogInformation($"Jugador registrado con éxito: ID={newPlayer.Id}, Nombre={newPlayer.Name}");
                return newPlayer.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al registrar un jugador.");
                throw new Exception("Ocurrió un error al registrar el jugador.", ex);
            }
        }
    }
}
