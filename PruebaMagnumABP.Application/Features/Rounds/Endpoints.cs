using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using PruebaMagnumABP.Application.Features.Round.Command;
using PruebaMagnumABP.Application.Features.Round.Queries;

namespace PruebaMagnumABP.Application.Features.Round
{
    public class Endpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/createNewRound", async (IMediator mediator, CreateNewRoundCommand command) =>
            {
                return await mediator.Send(command);
            }).WithTags("Round");

            app.MapGet("api/getRoundsHistory/{id}", async (IMediator mediator, int id) =>
            {
                return mediator.Send(new GetRoundsHistoryByGameIdQuery {GameId = id});
            }).WithTags("Round");
        }
    }
}
