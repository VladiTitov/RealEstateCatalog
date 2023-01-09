using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateCatalog.Infrastructure.Persistence.Context;
using RealEstateCatalog.Infrastructure.Persistence.Repositories;

namespace RealEstateCatalog.Infrastructure.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(nameof(ApplicationDbContext));
        return services
            .AddScoped<ICityRepository, CityRepository>()
            .AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString));
    }
}
