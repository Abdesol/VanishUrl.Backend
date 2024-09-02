using Microsoft.AspNetCore.Mvc;
using VanishUrl.Api.Dtos;
using VanishUrl.Api.Services;
using VanishUrl.Api.Services.Interfaces;

namespace VanishUrl.Api.Endpoints;

public static class Endpoints
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => Results.Ok("VanishUrl API"));

        app.MapGet("/{id}", async (string id, [FromServices] IDataService dataService) =>
        {
            if (!await dataService.DoesIdExist(id))
            {
                return Results.NotFound();
            }

            return Results.Text(await dataService.GetData(id), "text/plain");
        });

        app.MapPost("/set", async (SetDataRequest setDataRequest, [FromServices] IDataService dataService) =>
        {
            var id = await dataService.SetData(setDataRequest.Data);
            return Results.Created($"/{id}", new SetDataResponse(id));
        });
    }
}