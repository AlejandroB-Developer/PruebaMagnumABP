using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using PruebaMagnumABP.Application.Features.Player.Command;

namespace PruebaMagnumABP.Application.Features.Player
{
    public class Endpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/createNewPlayer", async (IMediator mediator, CreateNewPlayerCommand command) =>
            {
                return await mediator.Send(command);
            }).WithTags("Player");
        }
    }
}
