using Npgsql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateCatalog.Infrastructure.Persistence.Repositories;

namespace RealEstateCatalog.Infrastructure.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        var connectionStringFromConfiguration = configuration.GetConnectionString(nameof(ApplicationDbContext)) ??
            throw new ArgumentNullException(nameof(ApplicationDbContext));
        var builder = new NpgsqlConnectionStringBuilder(connectionStringFromConfiguration);
        builder.Password = configuration.GetSection("DBPassword").Value;
        var connectionString = builder.ConnectionString;

        return services
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString));
    }
}
