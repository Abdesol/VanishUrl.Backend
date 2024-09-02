using DotNetEnv;
using Microsoft.Azure.Cosmos;
using VanishUrl.Api.Configurations;
using VanishUrl.Api.Endpoints;
using VanishUrl.Api.Services;
using VanishUrl.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

Env.Load();
config.AddEnvironmentVariables();

builder.Services.AddCors(CorsConfig.CorsPolicyConfig);

builder.Services.AddSingleton(new CosmosClient(config["COSMOS_DB_ENDPOINT"], config["COSMOS_DB_KEY"]));
builder.Services.AddScoped<IDataService, DataService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CorsConfig.CorsPolicyName);

app.MapEndpoints();

app.Run();