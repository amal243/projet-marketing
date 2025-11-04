using gestion_marketing.Data;
using gestion_marketing.Helpers;
using gestion_marketing.Services.Interfaces;
using gestion_marketing.Services.Implementations; 
using gestion_marketing.DAL.Interfaces;           
using gestion_marketing.DAL.Repositories;        
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//  Connexion à PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//  Ajouter les services, repositories, etc.
builder.Services.AddScoped<ICampagneService, CampagneService>();
builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddScoped<ICampagneRepository, CampagneRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

//  AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//  Swagger + Controller
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  Middleware global d’erreur
var app = builder.Build();
app.UseMiddleware<ErrorHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
