using gestaoDeConsulta.Context;
using gestaoDeConsulta.Mappings;
using gestaoDeConsulta.Repositories;
using gestaoDeConsulta.Repositories.Interface;
using gestaoDeConsulta.Services;
using gestaoDeConsulta.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var myConnection = builder.Configuration.GetConnectionString("connectionDb");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(myConnection, ServerVersion.AutoDetect(myConnection)));

builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddScoped<IPatientService, PatientService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
