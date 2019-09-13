using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MIBI.Data.Migrations
{
    public partial class NutrientAgarPlateadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NutrientAgarPlates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutrientAgarPlates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SampleNutrientAgarPlate",
                columns: table => new
                {
                    SampleId = table.Column<Guid>(nullable: false),
                    NutrientAgarPlateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleNutrientAgarPlate", x => new { x.SampleId, x.NutrientAgarPlateId });
                    table.ForeignKey(
                        name: "FK_SampleNutrientAgarPlate_NutrientAgarPlates_NutrientAgarPlateId",
                        column: x => x.NutrientAgarPlateId,
                        principalTable: "NutrientAgarPlates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SampleNutrientAgarPlate_Samples_SampleId",
                        column: x => x.SampleId,
                        principalTable: "Samples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SampleNutrientAgarPlate_NutrientAgarPlateId",
                table: "SampleNutrientAgarPlate",
                column: "NutrientAgarPlateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SampleNutrientAgarPlate");

            migrationBuilder.DropTable(
                name: "NutrientAgarPlates");
        }
    }
}
