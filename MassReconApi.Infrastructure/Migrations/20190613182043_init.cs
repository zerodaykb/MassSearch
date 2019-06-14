using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MassReconApi.Infrastucture.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReconNote",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    DateOfUpdate = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReconNote", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    DateOfUpdate = table.Column<DateTime>(nullable: false),
                    SearchPhrase = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    DateOfUpdate = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    SourceType = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    IsChecked = table.Column<bool>(nullable: false),
                    ReportId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportItem_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportItem_ReportId",
                table: "ReportItem",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReconNote");

            migrationBuilder.DropTable(
                name: "ReportItem");

            migrationBuilder.DropTable(
                name: "Report");
        }
    }
}
