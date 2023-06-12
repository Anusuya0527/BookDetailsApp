using BookDetailsApp;
using BookDetailsApp.Interfaces;
using BookDetailsApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Retrieve the configuration from appsettings.json
var configuration = builder.Configuration;
string connectionString = configuration.GetConnectionString("Default");

// Add your DbContext to the services container
builder.Services.AddDbContext<BookDetailsDbContext>((serviceProvider, options) =>
{
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    });
}, ServiceLifetime.Scoped);


builder.Services.AddScoped<IBookAppService, BookAppService>();

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
