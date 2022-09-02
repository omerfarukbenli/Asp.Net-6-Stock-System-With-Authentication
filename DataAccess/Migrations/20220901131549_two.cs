using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StokApp.DataAccess.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "kalem1" },
                    { 2, "Kalem2" },
                    { 3, "Kalem3" },
                    { 4, "Kale4" },
                    { 5, "Kalem5" },
                    { 6, "Kalem6" },
                    { 7, "Kale7" },
                    { 8, "Kalem8" },
                    { 9, "Kalem9" },
                    { 10, "Kalem10" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "kalem1" },
                    { 2, 3, "Kalem2" },
                    { 3, 2, "Kalem3" },
                    { 4, 2, "Kale4" },
                    { 5, 4, "Kalem5" },
                    { 6, 3, "Kalem6" },
                    { 7, 4, "Kale7" },
                    { 8, 4, "Kalem8" },
                    { 9, 5, "Kalem9" },
                    { 10, 5, "Kalem10" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
