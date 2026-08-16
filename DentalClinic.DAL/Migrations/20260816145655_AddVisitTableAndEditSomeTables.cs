using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddVisitTableAndEditSomeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Appointment_AppointmentId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_Appointment_AppointmentId",
                table: "MedicalRecord");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "MedicalRecord",
                newName: "VisitId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalRecord_AppointmentId",
                table: "MedicalRecord",
                newName: "IX_MedicalRecord_VisitId");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Invoice",
                newName: "VisitId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_AppointmentId",
                table: "Invoice",
                newName: "IX_Invoice_VisitId");

            migrationBuilder.AlterColumn<int>(
                name: "ReceptionistId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    VisitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckInDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ReasonForVisit = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "Waiting"),
                    QueueNumber = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_Visit_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visit_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visit_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddCheckConstraint(
                name: "CK_InvoiceDetail_ExactlyOneItem",
                table: "InvoiceDetail",
                sql: "(MedicalRecordServiceId IS NOT NULL AND PrescriptionDetailId IS NULL) OR (MedicalRecordServiceId IS NULL AND PrescriptionDetailId IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_AppointmentId",
                table: "Visit",
                column: "AppointmentId",
                unique: true,
                filter: "[AppointmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_DoctorId",
                table: "Visit",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_PatientId",
                table: "Visit",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Visit_VisitId",
                table: "Invoice",
                column: "VisitId",
                principalTable: "Visit",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_Visit_VisitId",
                table: "MedicalRecord",
                column: "VisitId",
                principalTable: "Visit",
                principalColumn: "VisitId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Visit_VisitId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_Visit_VisitId",
                table: "MedicalRecord");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropCheckConstraint(
                name: "CK_InvoiceDetail_ExactlyOneItem",
                table: "InvoiceDetail");

            migrationBuilder.RenameColumn(
                name: "VisitId",
                table: "MedicalRecord",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalRecord_VisitId",
                table: "MedicalRecord",
                newName: "IX_MedicalRecord_AppointmentId");

            migrationBuilder.RenameColumn(
                name: "VisitId",
                table: "Invoice",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_VisitId",
                table: "Invoice",
                newName: "IX_Invoice_AppointmentId");

            migrationBuilder.AlterColumn<int>(
                name: "ReceptionistId",
                table: "Appointment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Appointment_AppointmentId",
                table: "Invoice",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_Appointment_AppointmentId",
                table: "MedicalRecord",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
