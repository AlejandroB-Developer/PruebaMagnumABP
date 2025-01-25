using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using PruebaMagnumABP.Application.Features.Game.Command;
using PruebaMagnumABP.Application.Features.Game.Queries;

namespace PruebaMagnumABP.Application.Features.Game
{
    public class Endpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/createNewGame", async (IMediator mediator, CreateNewGameCommand command) =>
            {
                return await mediator.Send(command);
            }).WithTags("Game");

            app.MapGet("api/getMoves", (IMediator mediator) =>
            {
                return mediator.Send(new GetMovesQuery());
            }).WithTags("Game");
        }
    }
}
