using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MIBI.Data.Migrations
{
    public partial class groipTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SampleImages_Samples_SampleId",
                table: "SampleImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SampleImages",
                table: "SampleImages");

            migrationBuilder.RenameTable(
                name: "SampleImages",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_SampleImages_SampleId",
                table: "Images",
                newName: "IX_Images_SampleId");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Samples",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Samples",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Images",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UploadedBy",
                table: "Images",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SampleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Samples_SampleId",
                        column: x => x.SampleId,
                        principalTable: "Samples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SampleId",
                table: "Groups",
                column: "SampleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Samples_SampleId",
                table: "Images",
                column: "SampleId",
                principalTable: "Samples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Samples_SampleId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Samples");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Samples");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "UploadedBy",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "SampleImages");

            migrationBuilder.RenameIndex(
                name: "IX_Images_SampleId",
                table: "SampleImages",
                newName: "IX_SampleImages_SampleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SampleImages",
                table: "SampleImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SampleImages_Samples_SampleId",
                table: "SampleImages",
                column: "SampleId",
                principalTable: "Samples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
