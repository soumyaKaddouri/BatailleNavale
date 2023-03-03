using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using NavalWar.Business;
using NavalWar.DAL;
using NavalWar.DAL.Repository.Sessions;
using NavalWar.DAL.Repository.Players;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// add your dependencies
builder.Services.AddScoped<ISessionService, SessionService >();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddDbContext<NavalContext>(options => 
options.UseSqlServer("Data Source=tcp:navalwarserver.database.windows.net,1433;Initial Catalog=NavalWar.DAL_db;User Id=NavalWar@navalwarserver;Password=Isima2023", builder => builder.EnableRetryOnFailure()));
//options.UseSqlServer("Server=navalwarsql.mysql.database.azure.com;Database=navalwardatabase;User Id=NavalWar;Password=Isima2023;"));
// Configure the HTTP request pipeline.
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
