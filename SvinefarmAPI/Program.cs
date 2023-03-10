using FluentAssertions.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyModel;
using SvinefarmAPI;
using SvinefarmAPI.Controllers;
using SvinefarmAPI.Interfaces;
using SvinefarmAPI.Model;
using SvinefarmAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILight, LightRepository>();
builder.Services.AddDbContext<ThePigFarmContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("?ThePigFarmContext")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("InitialRules",
                builder =>
                {
                    builder.AllowAnyOrigin() // kan skrive port i stedet for
                           .AllowAnyHeader()
                           .AllowAnyMethod(); // kun get eller put mm.
                });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("InitialRules");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


