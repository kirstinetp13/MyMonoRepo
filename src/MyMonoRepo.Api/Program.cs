// MyMonoRepo.Api - Minimal API host for vertical slice architecture
// https://jimmybogard.com/vertical-slice-architecture/

using MyMonoRepo.Api.Features.Example;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddOpenApi();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Root health check endpoint
app.MapGet("/", () => "Welcome to MyMonoRepo API")
    .WithName("Root")
    .WithDescription("Root endpoint - API is running");

// Map vertical slice endpoints
app.MapExampleEndpoints();

app.Run();
