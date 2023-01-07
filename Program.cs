using DesafioBackend;
using DesafioBackend.Context;
using DesafioBackend.Interfaces;
using DesafioBackend.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var startUp = new Startup(builder.Configuration);

startUp.ConfigureService(builder.Services);

builder.Services.AddDbContext<DesafioBackendContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("conexao")));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

var app = builder.Build();

startUp.Configure(app, app.Environment);

app.Run();
