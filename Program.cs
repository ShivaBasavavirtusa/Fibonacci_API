using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using GenerateFibonacci_Infrastructure;
using GnerateFibonacci_Core;
using GnerateFibonacci_Core.Handler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddMediatR(typeof(CalculateFibonacciHandler).Assembly) ;
builder.Services.AddScoped<IFibonacciService, FibonacciService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
