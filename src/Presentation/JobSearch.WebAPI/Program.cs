using JobSearch.Application.Extensions.WebAppBuilder;
using JobSearch.Domain.Entities.Identity;
using JobSearch.Infrastructure.Extensions.WebAppBuilder;
using JobSearch.Persistence.Extensions.WebAppBuilder;
using JobSearch.WebAPI.Extensions.WebAppBuilder;
using JobSearch.WebAPI.Helpers.Identity;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddAuthServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseGlobalExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthServices();

app.MapControllers();

app.Run();