using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogManagement.Infrastructure.EFCore.Migrations
{
    public partial class migactive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CommentActive",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentActive",
                table: "Articles");
        }
    }
}
