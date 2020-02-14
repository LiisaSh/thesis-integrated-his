using Microsoft.EntityFrameworkCore.Migrations;

namespace DHIS.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Idnumber",
                schema: "dbo",
                table: "Prescription",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idnumber",
                schema: "dbo",
                table: "Prescription");
        }
    }
}
