using PortfolioApp.Application.Extensions;
using PortfolioApp.Infrastructure.Extensions;
using PortfolioApp.WebApi.Extensions;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();
try
{
    Log.Information("Starting web host");
    var builder = WebApplication.CreateBuilder(args);



    builder.AddPresentation();
    builder.Services.AddApplicationServices();
    builder.Services.AddInfrastructure();
    builder.Services.AddDatabase(); // 
    builder.Services.AddJwtAuthentication(builder.Configuration.GetSection("JwtConfig"));



    builder.Services.AddOpenApi();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseSerilogRequestLogging();

    app.UseCors("myPolicyName");

    app.UseStatusCodePages();
    app.UseExceptionHandler(_ => { });
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.MapHealthChecks("/health");
    app.UseStatusCodePages();


    app.Run();


}
catch (System.Exception)
{
    Log.Fatal("Failed to start web host");
    throw;
}
finally
{
    Log.Information("Shutting down web host");
    Log.CloseAndFlush();
}


