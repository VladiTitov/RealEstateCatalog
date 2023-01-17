namespace RealEstateCatalog.Core.Domain.Dtos;

#nullable disable
public class PropertyListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PropertyType { get; set; }
    public string FurnishingType { get; set; }
    public int Price { get; set; }
    public int BHK { get; set; }
    public int BuildArea { get; set; }
    public string City { get; set; }
    public bool ReadyToMove { get; set; }
}
