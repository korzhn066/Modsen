using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Modsen.Application;
using Modsen.Application.Features.Book.Queries;
using Modsen.Application.Services;
using Modsen.Configuration;
using Modsen.Data;
using Modsen.Domain.Entities;
using Modsen.Domain.Repositories;
using Modsen.Domain.Services;
using Modsen.Exeptions;
using Modsen.Infrastructure;
using Modsen.Infrastructure.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGenConfiguration();

builder.Services
    .AddApplication()
    .AddInfrastructure();


builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentityConfiguration();

builder.Services.AddAuthenticateConfiguration(builder);

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();

builder.Services.AddScoped<IApplicationAuthenticationService, ApplicationAuthenticationService>();
builder.Services.AddScoped<ITokenProviderService, TokenProviderService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandlerMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
