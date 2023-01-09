namespace RealEstateCatalog.Infrastructure.Persistence.Context;

#nullable disable
public class ApplicationDbContext : DbContext
{
	public DbSet<City> Cities { get; set; }

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
		
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>().Property(i=>i.Id).UseIdentityAlwaysColumn();
        base.OnModelCreating(modelBuilder);
    }
}
