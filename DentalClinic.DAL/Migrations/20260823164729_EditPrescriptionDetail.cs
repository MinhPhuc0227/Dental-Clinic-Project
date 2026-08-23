using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditPrescriptionDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "PrescriptionDetail");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "PrescriptionDetail");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "PrescriptionDetail");

            migrationBuilder.AddColumn<int>(
                name: "Afternoon",
                table: "PrescriptionDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "PrescriptionDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Evening",
                table: "PrescriptionDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Instruction",
                table: "PrescriptionDetail",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Morning",
                table: "PrescriptionDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Noon",
                table: "PrescriptionDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Afternoon",
                table: "PrescriptionDetail");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "PrescriptionDetail");

            migrationBuilder.DropColumn(
                name: "Evening",
                table: "PrescriptionDetail");

            migrationBuilder.DropColumn(
                name: "Instruction",
                table: "PrescriptionDetail");

            migrationBuilder.DropColumn(
                name: "Morning",
                table: "PrescriptionDetail");

            migrationBuilder.DropColumn(
                name: "Noon",
                table: "PrescriptionDetail");

            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "PrescriptionDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "PrescriptionDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "PrescriptionDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
