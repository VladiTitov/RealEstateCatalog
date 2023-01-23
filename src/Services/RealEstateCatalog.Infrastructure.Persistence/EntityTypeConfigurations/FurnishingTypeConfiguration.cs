using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RealEstateCatalog.Infrastructure.Persistence.EntityTypeConfigurations;

internal class FurnishingTypeConfiguration : IEntityTypeConfiguration<FurnishingType>
{
    public void Configure(EntityTypeBuilder<FurnishingType> builder)
    {
        var datetimeNow = DateTime.Now;

        builder.HasData(
            new FurnishingType
            {
                Id = 1,
                Name = "Fully",
                LastUpdatedOn = datetimeNow,
                LastUpdatedBy = 1
            },
            new FurnishingType
            {
                Id = 2,
                Name = "Semi",
                LastUpdatedOn = datetimeNow,
                LastUpdatedBy = 1
            },
            new FurnishingType
            {
                Id = 3,
                Name = "Unfurnished",
                LastUpdatedOn = datetimeNow,
                LastUpdatedBy = 1
            });
    }
}
