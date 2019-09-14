using Microsoft.EntityFrameworkCore.Migrations;

namespace MIBI.Data.Migrations
{
    public partial class nutritionadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SampleNutrientAgarPlate_NutrientAgarPlates_NutrientAgarPlateId",
                table: "SampleNutrientAgarPlate");

            migrationBuilder.DropForeignKey(
                name: "FK_SampleNutrientAgarPlate_Samples_SampleId",
                table: "SampleNutrientAgarPlate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SampleNutrientAgarPlate",
                table: "SampleNutrientAgarPlate");

            migrationBuilder.RenameTable(
                name: "SampleNutrientAgarPlate",
                newName: "SampleNutrientAgarPlates");

            migrationBuilder.RenameIndex(
                name: "IX_SampleNutrientAgarPlate_NutrientAgarPlateId",
                table: "SampleNutrientAgarPlates",
                newName: "IX_SampleNutrientAgarPlates_NutrientAgarPlateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SampleNutrientAgarPlates",
                table: "SampleNutrientAgarPlates",
                columns: new[] { "SampleId", "NutrientAgarPlateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SampleNutrientAgarPlates_NutrientAgarPlates_NutrientAgarPlateId",
                table: "SampleNutrientAgarPlates",
                column: "NutrientAgarPlateId",
                principalTable: "NutrientAgarPlates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SampleNutrientAgarPlates_Samples_SampleId",
                table: "SampleNutrientAgarPlates",
                column: "SampleId",
                principalTable: "Samples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SampleNutrientAgarPlates_NutrientAgarPlates_NutrientAgarPlateId",
                table: "SampleNutrientAgarPlates");

            migrationBuilder.DropForeignKey(
                name: "FK_SampleNutrientAgarPlates_Samples_SampleId",
                table: "SampleNutrientAgarPlates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SampleNutrientAgarPlates",
                table: "SampleNutrientAgarPlates");

            migrationBuilder.RenameTable(
                name: "SampleNutrientAgarPlates",
                newName: "SampleNutrientAgarPlate");

            migrationBuilder.RenameIndex(
                name: "IX_SampleNutrientAgarPlates_NutrientAgarPlateId",
                table: "SampleNutrientAgarPlate",
                newName: "IX_SampleNutrientAgarPlate_NutrientAgarPlateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SampleNutrientAgarPlate",
                table: "SampleNutrientAgarPlate",
                columns: new[] { "SampleId", "NutrientAgarPlateId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SampleNutrientAgarPlate_NutrientAgarPlates_NutrientAgarPlateId",
                table: "SampleNutrientAgarPlate",
                column: "NutrientAgarPlateId",
                principalTable: "NutrientAgarPlates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SampleNutrientAgarPlate_Samples_SampleId",
                table: "SampleNutrientAgarPlate",
                column: "SampleId",
                principalTable: "Samples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
