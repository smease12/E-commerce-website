using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce_website.Migrations
{
    /// <inheritdoc />
    public partial class updateProductModelDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "Products",
                newName: "descriptionShort");

            migrationBuilder.AddColumn<string>(
                name: "descriptionLong",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descriptionLong",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "descriptionShort",
                table: "Products",
                newName: "description");
        }
    }
}
