using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinique.Data.Migrations
{
    public partial class AppointmentChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patients_PatientId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Appointment");

            migrationBuilder.AddColumn<string>(
                name: "Prescription",
                table: "PatientTests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentsId",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientDigsosisId",
                table: "Appointment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AppointmentsId",
                table: "Patients",
                column: "AppointmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientDigsosisId",
                table: "Appointment",
                column: "PatientDigsosisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_PatientTests_PatientDigsosisId",
                table: "Appointment",
                column: "PatientDigsosisId",
                principalTable: "PatientTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Appointment_AppointmentsId",
                table: "Patients",
                column: "AppointmentsId",
                principalTable: "Appointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_PatientTests_PatientDigsosisId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Appointment_AppointmentsId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AppointmentsId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_PatientDigsosisId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "Prescription",
                table: "PatientTests");

            migrationBuilder.DropColumn(
                name: "AppointmentsId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientDigsosisId",
                table: "Appointment");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Appointment",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patients_PatientId",
                table: "Appointment",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
