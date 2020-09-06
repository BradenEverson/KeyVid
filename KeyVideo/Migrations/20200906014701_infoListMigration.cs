using Microsoft.EntityFrameworkCore.Migrations;

namespace KeyVideo.Migrations
{
    public partial class infoListMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "infoList",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "infoList",
                table: "AspNetUsers");
        }
    }
}
