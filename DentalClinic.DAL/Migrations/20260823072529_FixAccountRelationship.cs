using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixAccountRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Account_AccountId1",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Receptionist_Account_AccountId1",
                table: "Receptionist");

            migrationBuilder.DropIndex(
                name: "IX_Receptionist_AccountId1",
                table: "Receptionist");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_AccountId1",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "Doctor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId1",
                table: "Receptionist",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId1",
                table: "Doctor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receptionist_AccountId1",
                table: "Receptionist",
                column: "AccountId1",
                unique: true,
                filter: "[AccountId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_AccountId1",
                table: "Doctor",
                column: "AccountId1",
                unique: true,
                filter: "[AccountId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Account_AccountId1",
                table: "Doctor",
                column: "AccountId1",
                principalTable: "Account",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receptionist_Account_AccountId1",
                table: "Receptionist",
                column: "AccountId1",
                principalTable: "Account",
                principalColumn: "AccountId");
        }
    }
}
