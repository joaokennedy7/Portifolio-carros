using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortifolioCarros.API.Configurations;
using PortifolioCarros.API.Persistence.SqlServer;
using PortifolioCarros.API.Persistence.SqlServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.ConfigureAutoMapper();

builder.Services.AddDbContext<PortifolioContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("PortifolioDb"))
);

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
