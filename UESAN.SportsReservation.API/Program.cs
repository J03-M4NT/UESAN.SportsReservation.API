using Microsoft.EntityFrameworkCore;
using UESAN.SportsReservation.API.Infrastructure.Data;
using UESAN.SportsReservation.CORE.Core.Interfaces;
using UESAN.SportsReservation.CORE.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var _configuration = builder.Configuration;

var connectionString = _configuration
                        .GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<SportsReservationDbContext>(options =>
    options.UseSqlServer(connectionString));


// TODO: Add Interfaces
builder.Services.AddScoped<ICanchaRepository, CanchasRepository>();



// - - - - - - - - 

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

// Programa Inicial