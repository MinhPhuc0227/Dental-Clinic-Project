using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditMedicineImport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineImport_Receptionist_ReceptionistId",
                table: "MedicineImport");

            migrationBuilder.RenameColumn(
                name: "ReceptionistId",
                table: "MedicineImport",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicineImport_ReceptionistId",
                table: "MedicineImport",
                newName: "IX_MedicineImport_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineImport_Account_AccountId",
                table: "MedicineImport",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineImport_Account_AccountId",
                table: "MedicineImport");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "MedicineImport",
                newName: "ReceptionistId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicineImport_AccountId",
                table: "MedicineImport",
                newName: "IX_MedicineImport_ReceptionistId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineImport_Receptionist_ReceptionistId",
                table: "MedicineImport",
                column: "ReceptionistId",
                principalTable: "Receptionist",
                principalColumn: "ReceptionistId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
