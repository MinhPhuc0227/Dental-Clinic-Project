using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentMethodToMedicineImport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodId",
                table: "MedicineImport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MedicineImport_PaymentMethodId",
                table: "MedicineImport",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineImport_PaymentMethod_PaymentMethodId",
                table: "MedicineImport",
                column: "PaymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineImport_PaymentMethod_PaymentMethodId",
                table: "MedicineImport");

            migrationBuilder.DropIndex(
                name: "IX_MedicineImport_PaymentMethodId",
                table: "MedicineImport");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "MedicineImport");
        }
    }
}
