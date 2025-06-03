using Microsoft.EntityFrameworkCore.Migrations;

namespace LanguageManagement.Infrastructure.EFCore.Migrations
{
    public partial class mig_LanguageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LanguageNameEn",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageNameFa",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageNameEn",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageNameFa",
                table: "Languages");
        }
    }
}
