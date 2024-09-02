using VanishUrl.Api.Configurations;
using VanishUrl.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(CorsConfig.CorsPolicyConfig);
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