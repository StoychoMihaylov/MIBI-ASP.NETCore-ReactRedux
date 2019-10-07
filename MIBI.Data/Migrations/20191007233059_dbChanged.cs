using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MIBI.Data.Migrations
{
    public partial class dbChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Samples_SampleId",
                table: "Images");

            migrationBuilder.AlterColumn<Guid>(
                name: "SampleId",
                table: "Images",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Samples_SampleId",
                table: "Images",
                column: "SampleId",
                principalTable: "Samples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Samples_SampleId",
                table: "Images");

            migrationBuilder.AlterColumn<Guid>(
                name: "SampleId",
                table: "Images",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Samples_SampleId",
                table: "Images",
                column: "SampleId",
                principalTable: "Samples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
