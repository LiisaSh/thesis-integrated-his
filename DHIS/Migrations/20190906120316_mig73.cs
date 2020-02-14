using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DHIS.Migrations
{
    public partial class mig73 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created_by",
                schema: "dbo",
                table: "Pharmacy");

            migrationBuilder.DropColumn(
                name: "Created_on",
                schema: "dbo",
                table: "Pharmacy");

            migrationBuilder.DropColumn(
                name: "Modified_by",
                schema: "dbo",
                table: "Pharmacy");

            migrationBuilder.DropColumn(
                name: "Modified_on",
                schema: "dbo",
                table: "Pharmacy");

            migrationBuilder.DropColumn(
                name: "Created_by",
                schema: "dbo",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "Created_on",
                schema: "dbo",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "Modified_by",
                schema: "dbo",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "Modified_on",
                schema: "dbo",
                table: "Medicine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Created_by",
                schema: "dbo",
                table: "Pharmacy",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_on",
                schema: "dbo",
                table: "Pharmacy",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Modified_by",
                schema: "dbo",
                table: "Pharmacy",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified_on",
                schema: "dbo",
                table: "Pharmacy",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Created_by",
                schema: "dbo",
                table: "Medicine",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_on",
                schema: "dbo",
                table: "Medicine",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Modified_by",
                schema: "dbo",
                table: "Medicine",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified_on",
                schema: "dbo",
                table: "Medicine",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
