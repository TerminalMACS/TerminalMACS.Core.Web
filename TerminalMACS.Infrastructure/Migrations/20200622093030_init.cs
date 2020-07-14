using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TerminalMACS.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelAs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelAs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ModelAId = table.Column<int>(nullable: false),
                    testAId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelBs_ModelAs_testAId",
                        column: x => x.testAId,
                        principalTable: "ModelAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelBs_testAId",
                table: "ModelBs",
                column: "testAId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelBs");

            migrationBuilder.DropTable(
                name: "ModelAs");
        }
    }
}
