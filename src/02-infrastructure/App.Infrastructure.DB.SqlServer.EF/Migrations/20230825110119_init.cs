using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.DB.SqlServer.EF.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberofProducts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "NumberofProducts", "Price", "Title" },
                values: new object[] { 1, "Product Description1", 0, 10000, "Product Title1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "NumberofProducts", "Price", "Title" },
                values: new object[] { 2, "Product Description2", 0, 10000, "Product Title2" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "NumberofProducts", "Price", "Title" },
                values: new object[] { 3, "Product Description3", 0, 10000, "Product Title3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
