using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateCatalog.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateUserForPasswordEncryption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"ALTER TABLE \"Users\" ALTER COLUMN \"Password\" TYPE bytea USING \"Password\"::TEXT::BYTEA");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordKey",
                table: "Users",
                type: "bytea",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordKey",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);
        }
    }
}
