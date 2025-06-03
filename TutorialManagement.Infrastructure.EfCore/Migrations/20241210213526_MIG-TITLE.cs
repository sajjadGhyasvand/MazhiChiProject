using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorialManagement.Infrastructure.EfCore.Migrations
{
    public partial class MIGTITLE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TutorialVideo",
                newName: "TitleRu");

            migrationBuilder.AlterColumn<string>(
                name: "LinkAr",
                table: "TutorialVideo",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleAr",
                table: "TutorialVideo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                table: "TutorialVideo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleFa",
                table: "TutorialVideo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "VideoViews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    ViewTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoViews", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoViews");

            migrationBuilder.DropColumn(
                name: "TitleAr",
                table: "TutorialVideo");

            migrationBuilder.DropColumn(
                name: "TitleEn",
                table: "TutorialVideo");

            migrationBuilder.DropColumn(
                name: "TitleFa",
                table: "TutorialVideo");

            migrationBuilder.RenameColumn(
                name: "TitleRu",
                table: "TutorialVideo",
                newName: "Title");

            migrationBuilder.AlterColumn<string>(
                name: "LinkAr",
                table: "TutorialVideo",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);
        }
    }
}
