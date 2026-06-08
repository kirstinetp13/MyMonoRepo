// Example vertical slice showing feature encapsulation pattern
// See: https://jimmybogard.com/vertical-slice-architecture/
// This demonstrates how to structure a complete feature (endpoint, handler, models)

using MediatR;

namespace MyMonoRepo.Api.Features.Example;

/// <summary>
/// Example MediatR query for retrieving an item.
/// Follows CQRS pattern: https://martinfowler.com/bliki/CQRS.html
/// </summary>
public record GetExampleItemQuery(int Id) : IRequest<ExampleItemDto>;

/// <summary>
/// Query handler for GetExampleItemQuery.
/// Injected via dependency injection: https://learn.microsoft.com/dotnet/core/extensions/dependency-injection
/// </summary>
public class GetExampleItemQueryHandler : IRequestHandler<GetExampleItemQuery, ExampleItemDto>
{
    public Task<ExampleItemDto> Handle(GetExampleItemQuery request, CancellationToken cancellationToken)
    {
        // Replace with actual business logic and data access
        var result = new ExampleItemDto
        {
            Id = request.Id,
            Name = "Example Item",
            CreatedAt = DateTime.UtcNow
        };

        return Task.FromResult(result);
    }
}

/// <summary>
/// Data transfer object for example items.
/// </summary>
public class ExampleItemDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

/// <summary>
/// Minimal API endpoints for the Example feature.
/// </summary>
public static class ExampleEndpoints
{
    public static void MapExampleEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/example")
            .WithName("Example")
            .WithDescription("Example feature endpoints");

        group.MapGet("/{id:int}", GetItem)
            .WithName("GetExampleItem");
    }

    private static async Task<IResult> GetItem(int id, IMediator mediator, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetExampleItemQuery(id), cancellationToken);
        return Results.Ok(result);
    }
}
