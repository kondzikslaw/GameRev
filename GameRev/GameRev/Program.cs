using FluentValidation.AspNetCore;
using GameRev;
using GameRev.ApplicationServices;
using GameRev.ApplicationServices.API.Domain.Responses;
using GameRev.ApplicationServices.API.Validators.Reviews;
using GameRev.ApplicationServices.Components.GiantBomb;
using GameRev.ApplicationServices.Mappings;
using GameRev.Authentication;
using GameRev.DataAccess;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

builder.Services.AddLogging();

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Add services to the container.
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddReviewsRequestValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();

var apiKey = builder.Configuration["ApiKey"];
builder.Services.Configure<ApiConfig>(config =>
{
    config.ApiKey = apiKey;
});

builder.Services.AddTransient<IGiantBombConnector, GiantBombConnector>();

builder.Services.AddAutoMapper(typeof(GamesProfile).Assembly);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ResponseBase<>).Assembly));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



builder.Services.AddDbContext<GameRevStorageContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("AzureGameRevDatabaseConnection")));

var MyCorsPolicy = "_myCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyCorsPolicy,
        builder =>
        {
            builder
            .WithOrigins("https://gamerevclient.azurewebsites.net")
            //.AllowAnyOrigin()
            //.WithOrigins("https://localhost:7137")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.MapGet("/", (GiantBombConnector giantBombConnector, IConfiguration configuration) =>
//{
//    giantBombConnector.UseApiKey();
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
