using FluentValidation.AspNetCore;
using JobSearch.Application.Extensions.WebAppBuilder;
using JobSearch.Application.Validators.Identity;
using JobSearch.Infrastructure.Extensions.WebAppBuilder;
using JobSearch.Persistence.Extensions.WebAppBuilder;
using JobSearch.WebAPI.Extensions.WebAppBuilder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<UserCreateValidator>());

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();

builder.Services.AddAuthServices(builder.Configuration);
builder.Services.AddPresentationServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseGlobalExceptionHandler();
}

app.UseAuthServices();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();