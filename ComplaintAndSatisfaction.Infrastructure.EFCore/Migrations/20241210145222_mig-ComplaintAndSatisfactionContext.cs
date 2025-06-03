using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplaintAndSatisfaction.Infrastructure.EFCore.Migrations
{
    public partial class migComplaintAndSatisfactionContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplaintAndSatisfaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SatisfactionLevel = table.Column<long>(type: "bigint", nullable: false),
                    SatisfactionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Report = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAnswer = table.Column<bool>(type: "bit", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintAndSatisfaction", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplaintAndSatisfaction");
        }
    }
}
