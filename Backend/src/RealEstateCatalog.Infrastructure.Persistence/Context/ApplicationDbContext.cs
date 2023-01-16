﻿namespace RealEstateCatalog.Infrastructure.Persistence.Context;

#nullable disable
public class ApplicationDbContext : DbContext
{
	public DbSet<City> Cities { get; set; }
    public DbSet<User> Users { get; set; }
	public DbSet<Property> Properties { get; set; }
	public DbSet<FurnishingType> FurnishingTypes { get; set; }
	public DbSet<PropertyType> PropertyTypes { get; set; }

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{ }
}
