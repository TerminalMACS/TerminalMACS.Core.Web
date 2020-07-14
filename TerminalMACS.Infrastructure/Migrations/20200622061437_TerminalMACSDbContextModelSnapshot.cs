using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TerminalMACS.Infrastructure.Migrations
{
    public partial class TerminalMACSDbContextModelSnapshot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "testA",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "testB",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ModelAId = table.Column<int>(nullable: false),
                    modelAId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_testB_testA_modelAId",
                        column: x => x.modelAId,
                        principalTable: "testA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_testB_modelAId",
                table: "testB",
                column: "modelAId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "testB");

            migrationBuilder.DropTable(
                name: "testA");
        }
    }
}
