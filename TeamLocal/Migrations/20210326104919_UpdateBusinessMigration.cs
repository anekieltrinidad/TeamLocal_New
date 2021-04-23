using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamLocal.Migrations
{
    public partial class UpdateBusinessMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryBusinessCategoryID",
                table: "Businesses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryBusinesses",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBusinesses", x => x.CategoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_CategoryBusinessCategoryID",
                table: "Businesses",
                column: "CategoryBusinessCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_CategoryBusinesses_CategoryBusinessCategoryID",
                table: "Businesses",
                column: "CategoryBusinessCategoryID",
                principalTable: "CategoryBusinesses",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_CategoryBusinesses_CategoryBusinessCategoryID",
                table: "Businesses");

            migrationBuilder.DropTable(
                name: "CategoryBusinesses");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_CategoryBusinessCategoryID",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "CategoryBusinessCategoryID",
                table: "Businesses");
        }
    }
}
