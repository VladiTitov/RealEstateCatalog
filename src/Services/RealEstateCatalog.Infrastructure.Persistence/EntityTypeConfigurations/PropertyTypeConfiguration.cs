using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RealEstateCatalog.Infrastructure.Persistence.EntityTypeConfigurations;

internal class PropertyTypeConfiguration : IEntityTypeConfiguration<PropertyType>
{
    public void Configure(EntityTypeBuilder<PropertyType> builder)
    {
        var datetimeNow = DateTime.Now;

        builder.HasData(
            new PropertyType 
            { 
                Id = 1, 
                Name = "House", 
                LastUpdatedOn = datetimeNow, 
                LastUpdatedBy = 1 
            },
            new PropertyType 
            { 
                Id = 2, 
                Name = "Apartment", 
                LastUpdatedOn = datetimeNow, 
                LastUpdatedBy = 1 
            },
            new PropertyType 
            { 
                Id = 3, 
                Name = "Duplex", 
                LastUpdatedOn = datetimeNow, 
                LastUpdatedBy = 1 
            });
    }
}
