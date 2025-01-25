using Microsoft.Extensions.Logging;
using Moq;
using PruebaMagnumABP.Application.Features.Game.Command;
using PruebaMagnumABP.Application.Interfaces.Services;

namespace PruebaMagnumABP.Tests
{
    public class CreateNewGameCommandHandlerTests
    {
        private readonly Mock<ILogger<CreateNewGameCommandHandler>> _mockLogger;
        private readonly Mock<IGameService> _mockGameService;
        private readonly CreateNewGameCommandHandler _handler;

        public CreateNewGameCommandHandlerTests()
        {
            _mockLogger = new Mock<ILogger<CreateNewGameCommandHandler>>();
            _mockGameService = new Mock<IGameService>();
            _handler = new CreateNewGameCommandHandler(_mockLogger.Object, _mockGameService.Object);
        }

        [Fact]
        public async Task Handle_ShouldRegisterNewGame_WhenNotFinished()
        {
            // Arrange
            var request = new CreateNewGameCommand
            {
                Player1Id = 1,
                Player2Id = 2,
                IsFinished = false
            };

            _mockGameService.Setup(gs => gs.RegisterNewGameAsync(It.IsAny<CreateNewGameCommand>(), It.IsAny<CancellationToken>()))
                            .ReturnsAsync(1); // Simula que el juego registrado tiene ID 1

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(1, result); // Verifica que el ID del nuevo juego sea 1
            _mockGameService.Verify(gs => gs.RegisterNewGameAsync(It.IsAny<CreateNewGameCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldUpdateExistingGame_WhenFinished()
        {
            // Arrange
            var request = new CreateNewGameCommand
            {
                GameId = 1,
                Player1Id = 1,
                Player2Id = 2,
                IsFinished = true
            };

            _mockGameService.Setup(gs => gs.UpdateExistingGameAsync(It.IsAny<CreateNewGameCommand>(), It.IsAny<CancellationToken>()))
                            .ReturnsAsync(1); // Simula que el juego actualizado tiene ID 1

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(1, result); // Verifica que el ID del juego actualizado sea 1
            _mockGameService.Verify(gs => gs.UpdateExistingGameAsync(It.IsAny<CreateNewGameCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
