// Extension methods for service registration in vertical slices
// Follows dependency injection best practices: https://learn.microsoft.com/dotnet/core/extensions/dependency-injection

namespace MyMonoRepo.Api.Common;

/// <summary>
/// Provides extension methods for registering vertical slice handlers and services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds all MediatR handlers from features (vertical slices).
    /// </summary>
    public static IServiceCollection AddFeatureHandlers(this IServiceCollection services)
    {
        // MediatR is already configured in Program.cs
        // Add feature-specific services here as needed
        return services;
    }
}
