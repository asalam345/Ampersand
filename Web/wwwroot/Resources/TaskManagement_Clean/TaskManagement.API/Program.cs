using Serilog;
using Serilog.Events;
using TaskManagement.API.Middlewares;
using TaskManagement.Application.Extensions;
using TaskManagement.Infrastructure.Extensions;


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
#region Serilog instantiation
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateBootstrapLogger();
#endregion
try
{
    Log.Information("Application Starting....");
    var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddSwagger();
    builder.Services.AddJwtAuthentication(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    #region Serilog Configuration
    builder.Host.UseSerilog((context, lc) =>
        lc.MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(builder.Configuration)
    );
    #endregion
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMiddleware<ExceptionHandlerMiddleware>();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application Crashed");

}
finally
{
    Log.CloseAndFlush();
}

