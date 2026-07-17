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

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactClient", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.MapOpenApi();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(
        "/openapi/v1.json",
        "Research Tracker API v1");
});

app.UseCors("ReactClient");

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
