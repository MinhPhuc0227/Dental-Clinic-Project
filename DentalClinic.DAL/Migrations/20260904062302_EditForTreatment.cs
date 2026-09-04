using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EditForTreatment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "Visit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreatmentSessionNumber",
                table: "Visit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLongTerm",
                table: "Service",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "MedicalRecord",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    TreatmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Unpaid"),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "InProgress"),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.TreatmentId);
                    table.ForeignKey(
                        name: "FK_Treatment_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Treatment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Treatment_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visit_TreatmentId",
                table: "Visit",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_DoctorId",
                table: "Treatment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_PatientId",
                table: "Treatment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_ServiceId",
                table: "Treatment",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Treatment_TreatmentId",
                table: "Visit",
                column: "TreatmentId",
                principalTable: "Treatment",
                principalColumn: "TreatmentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Treatment_TreatmentId",
                table: "Visit");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropIndex(
                name: "IX_Visit_TreatmentId",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "TreatmentSessionNumber",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "IsLongTerm",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "MedicalRecord");
        }
    }
}
