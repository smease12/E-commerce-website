using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce_website.Migrations
{
    /// <inheritdoc />
    public partial class createUserCartModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCarts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCarts_Products_Productid",
                        column: x => x.Productid,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCarts_ApplicationUserId",
                table: "UserCarts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCarts_Productid",
                table: "UserCarts",
                column: "Productid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCarts");
        }
    }
}
