using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamLocal.Migrations
{
    public partial class AddBusinessIDToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessID",
                table: "AspNetUsers");
        }
    }
}
