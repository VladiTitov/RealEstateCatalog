namespace RealEstateCatalog.Core.Domain.Models;

#nullable disable
public class City : BaseEntity
{
    public string Name { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public int LastUpdatedBy { get; set; }
}
