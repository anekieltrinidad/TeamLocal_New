using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamLocal.Migrations
{
    public partial class Businesses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_CategoryBusinesses_CategoryBusinessCategoryID",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Businesses");

            migrationBuilder.RenameColumn(
                name: "CategoryBusinessCategoryID",
                table: "Businesses",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Businesses_CategoryBusinessCategoryID",
                table: "Businesses",
                newName: "IX_Businesses_CategoryID");

            migrationBuilder.CreateTable(
                name: "ProjectRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRole", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_CategoryBusinesses_CategoryID",
                table: "Businesses",
                column: "CategoryID",
                principalTable: "CategoryBusinesses",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_CategoryBusinesses_CategoryID",
                table: "Businesses");

            migrationBuilder.DropTable(
                name: "ProjectRole");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Businesses",
                newName: "CategoryBusinessCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Businesses_CategoryID",
                table: "Businesses",
                newName: "IX_Businesses_CategoryBusinessCategoryID");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Businesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_CategoryBusinesses_CategoryBusinessCategoryID",
                table: "Businesses",
                column: "CategoryBusinessCategoryID",
                principalTable: "CategoryBusinesses",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
