using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAccountFromPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Account_AccountId",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_AccountId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Patient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Patient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_AccountId",
                table: "Patient",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Account_AccountId",
                table: "Patient",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
