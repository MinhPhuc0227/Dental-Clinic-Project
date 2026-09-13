using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVisitInvoiceToOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoice_VisitId",
                table: "Invoice");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_VisitId",
                table: "Invoice",
                column: "VisitId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoice_VisitId",
                table: "Invoice");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_VisitId",
                table: "Invoice",
                column: "VisitId");
        }
    }
}
