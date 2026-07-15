using Microsoft.EntityFrameworkCore;
using ResearchTrackerApi.Data;
using ResearchTrackerApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();

var connectionString = builder.Configuration.GetConnectionString(
    "ResearchTrackerDatabase");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("The ResearchTrackerDatabase connection string was not found.");
}

builder.Services.AddDbContext<ResearchTrackerDBContext>(options => 
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IResearchProjectService, ResearchProjectService>();

var app = builder.Build();

var safeConnectionDetails =
    new Microsoft.Data.SqlClient.SqlConnectionStringBuilder(connectionString);

app.Logger.LogWarning(
    "DATABASE CHECK: Server={Server}; Database={Database}",
    safeConnectionDetails.DataSource,
    safeConnectionDetails.InitialCatalog);

app.Logger.LogWarning("TEST 3: ILogger executed");

app.MapOpenApi();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(
        "/openapi/v1.json",
        "Research Tracker API v1");
});

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
