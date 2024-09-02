using VanishUrl.Api.Dtos;

namespace VanishUrl.Api.Endpoints;

public static class Endpoints
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => Results.Ok("VanishUrl API"));

        app.MapGet("/{id}", async (string id) =>
        {
            return Results.Ok($"This is the text: {id}");
        });

        app.MapPost("/set", async (SetDataRequest setDataRequest) =>
        {
            return Results.Ok(new SetDataResponse("This is the text"));
        });
    }
}