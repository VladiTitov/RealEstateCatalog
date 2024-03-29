﻿namespace RealEstateCatalog.Core.Domain.Dtos;

#nullable disable
public class PropertyDto
{
    public int SellRent { get; set; }
    public string Name { get; set; }
    public int PropertyTypeId { get; set; }
    public int BHK { get; set; }
    public int FurnishingTypeId { get; set; }
    public int Price { get; set; }
    public int BuildArea { get; set; }
    public int CityId { get; set; }
    public bool ReadyToMove { get; set; }
    public DateTime EstPossessionOn { get; set; }
    public int CarpetArea { get; set; }
    public string Address { get; set; }
    public string Address2 { get; set; }
    public int FloorNo { get; set; }
    public int TotalFloor { get; set; }
    public string MainEntrance { get; set; }
    public int Security { get; set; }
    public bool Gated { get; set; }
    public int Maintenance { get; set; }
    public string Age { get; set; }
    public string Description { get; set; }
}
