using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce_website.Migrations
{
    /// <inheritdoc />
    public partial class addAddressToUserCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "UserCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "UserCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UserCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "UserCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "UserCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "UserCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "UserCarts",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                table: "UserCarts");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "UserCarts");

            migrationBuilder.DropColumn(
                name: "City",
                table: "UserCarts");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "UserCarts");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "UserCarts");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserCarts");

            migrationBuilder.DropColumn(
                name: "State",
                table: "UserCarts");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "UserCarts");
        }
    }
}
