using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorialManagement.Infrastructure.EfCore.Migrations
{
    public partial class migTutorialContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IntroductionVideo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntroductionVideo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TutorialVideo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LinkFa = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    LinkEn = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    LinkAr = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    LinkRu = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Poster = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorialVideo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntroductionVideo");

            migrationBuilder.DropTable(
                name: "TutorialVideo");
        }
    }
}
