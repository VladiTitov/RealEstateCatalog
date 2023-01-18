using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateCatalog.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addPropertyDataForTests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "LastUpdatedBy", "LastUpdatedOn" },
                values: new object[] { 1, "Atlanta", 1, DateTime.Now });

            migrationBuilder.InsertData(
                table: "FurnishingTypes",
                columns: new[] { "Id", "Name", "LastUpdatedOn", "LastUpdatedBy" },
                values: new object[] { 1, "Fully", DateTime.Now, 1 });

            migrationBuilder.InsertData(
                table: "PropertyTypes",
                columns: new[] { "Id", "Name", "LastUpdatedBy", "LastUpdatedOn" },
                values: new object[] { 1, "House", 1, DateTime.Now });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { 
                    "Id", 
                    "SellRent", 
                    "Name",
                    "PropertyTypeId", 
                    "BHK",
                    "FurnishingTypeId", 
                    "Price",
                    "BuildArea",
                    "CarpetArea",
                    "Address", 
                    "Address2",
                    "CityId",
                    "FloorNo", 
                    "TotalFloor",
                    "ReadyToMove",
                    "MainEntrance",
                    "Security", 
                    "Gated",
                    "Maintenance",
                    "EstPossessionOn", 
                    "Age",
                    "Description",
                    "PostedOn", 
                    "PostedBy", 
                    "LastUpdatedOn", 
                    "LastUpdatedBy" },
                values: new object[] 
                { 
                    1, 
                    1, 
                    "Birla House", 
                    1, 
                    2, 
                    1, 
                    12000, 
                    12000, 
                    9000, 
                    "6 Street", 
                    "Golf Course Road", 
                    1, 
                    3, 
                    3, 
                    true, 
                    "East",
                    0,
                    true, 
                    300,
                    DateTime.Now, 
                    5, 
                    "Well Maintained builder floor available for rent at prime location. # property features- - 5 mins away from metro station - Gated community - 24*7 security. # property includes- - Big rooms (Cross ventilation & proper sunlight) - Drawing and dining area - Washrooms - Balcony - Modular kitchen - Near gym, market, temple and park - Easy commuting to major destination. Feel free to call With Query.",
                    DateTime.Now,
                    2,
                    DateTime.Now,
                    1
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FurnishingTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
