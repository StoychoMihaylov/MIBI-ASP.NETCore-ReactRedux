using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MIBI.Data.Migrations
{
    public partial class imgEntityChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "UploadedBy",
                table: "Images");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Images",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UploadedBy",
                table: "Images",
                nullable: true);
        }
    }
}
