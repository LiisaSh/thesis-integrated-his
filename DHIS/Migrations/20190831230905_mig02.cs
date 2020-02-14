using Microsoft.EntityFrameworkCore.Migrations;

namespace DHIS.Migrations
{
    public partial class mig02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_Pharmacy_PharmacyMedicID",
                schema: "dbo",
                table: "Medicine");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_Pharmacy_PharmacyMedicID",
                schema: "dbo",
                table: "Medicine",
                column: "PharmacyMedicID",
                principalSchema: "dbo",
                principalTable: "Pharmacy",
                principalColumn: "PharmacyID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicine_Pharmacy_PharmacyMedicID",
                schema: "dbo",
                table: "Medicine");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicine_Pharmacy_PharmacyMedicID",
                schema: "dbo",
                table: "Medicine",
                column: "PharmacyMedicID",
                principalSchema: "dbo",
                principalTable: "Pharmacy",
                principalColumn: "PharmacyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
