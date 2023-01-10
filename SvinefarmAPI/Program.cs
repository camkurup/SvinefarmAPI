using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using SvinefarmAPI.Helpers;
using SvinefarmAPI.Interfaces;
using SvinefarmAPI.Model;
using SvinefarmAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
    x => x.UseNpgsql("name=ConnectionStrings:ThePigFarm"));

builder.Services.AddScoped<ILightRepository, LightRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
