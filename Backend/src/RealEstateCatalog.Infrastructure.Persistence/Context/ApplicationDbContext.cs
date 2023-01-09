namespace RealEstateCatalog.Infrastructure.Persistence.Context;

#nullable disable
public class ApplicationDbContext : DbContext
{
	public DbSet<City> Cities { get; set; }

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
		
	}
}
