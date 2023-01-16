using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YoutubeShareAPI;
using YoutubeShareData.Models;
using YoutubeShareManager.Handler;
using MediatR;
using System.Reflection;
using YoutubeShareManager.Repository;
using YoutubeShareManager.Factory;
using YoutubeShareManager.Domain;

var options = new WebApplicationOptions
{
    Args = args,
    ContentRootPath = AppContext.BaseDirectory
};

var builder = WebApplication.CreateBuilder(options);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureService(builder.Services);
ConfigureApp(builder);


void ConfigureApp(WebApplicationBuilder builder)
{
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors(ConfigurationValues.CORS_DOMAIN);
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

void ConfigureService(IServiceCollection services)
{
    services.AddCors(options =>
    {
        options.AddPolicy(ConfigurationValues.CORS_DOMAIN,
            policy => policy.WithOrigins(ConfigurationValues.CORS_ORIGINS).AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
    });

    services.AddEntityFrameworkSqlServer()
        .AddDbContextPool<YoutubeShareContext>(options => options.UseSqlServer(ConfigurationValues.DATABASE_CONNECTION_STRING));
    YoutubeShareContext.ConnectionString= ConfigurationValues.DATABASE_CONNECTION_STRING;
    services.AddDbContext<YoutubeShareContext>(options => options.UseSqlServer(ConfigurationValues.DATABASE_CONNECTION_STRING));

    services.AddMediatR(typeof(YoutubeVideoEventQueryHandler).Assembly);
}
