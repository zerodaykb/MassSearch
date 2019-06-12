using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MassReconApi.Infrastucture.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SingleResult",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    DateOfUpdate = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    SourceType = table.Column<string>(nullable: true),
                    IsChecked = table.Column<bool>(nullable: false),
                    ReportId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleResult_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SingleResult_ReportId",
                table: "SingleResult",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SingleResult");

            migrationBuilder.DropTable(
                name: "Report");
        }
    }
}
