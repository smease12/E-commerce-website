using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce_website.Migrations
{
    /// <inheritdoc />
    public partial class addAddresstoApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressCity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressStreet",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressUnitNum",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressZipCode",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressCity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressStreet",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressUnitNum",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressZipCode",
                table: "AspNetUsers");
        }
    }
}
