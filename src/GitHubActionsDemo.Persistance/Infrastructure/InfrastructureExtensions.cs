using GitHubActionsDemo.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace GitHubActionsDemo.Service.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddPersistanceDependencies(this IServiceCollection services)
        {
            return services.AddSingleton<ILibraryRespository, LibraryRespository>();
        }
    }
}