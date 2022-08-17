using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    public partial class AllRelationshipAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Professionals_ProfessionalId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Specialties_SpecialtyId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "ProfessionalId",
                table: "Appointments",
                newName: "id_professional");

            migrationBuilder.RenameColumn(
                name: "SpecialtyId",
                table: "Appointments",
                newName: "id_speciality");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_SpecialtyId",
                table: "Appointments",
                newName: "IX_Appointments_id_speciality");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ProfessionalId",
                table: "Appointments",
                newName: "IX_Appointments_id_professional");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Professionals_id_professional",
                table: "Appointments",
                column: "id_professional",
                principalTable: "Professionals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Specialties_id_speciality",
                table: "Appointments",
                column: "id_speciality",
                principalTable: "Specialties",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Professionals_id_professional",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Specialties_id_speciality",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "id_professional",
                table: "Appointments",
                newName: "ProfessionalId");

            migrationBuilder.RenameColumn(
                name: "id_speciality",
                table: "Appointments",
                newName: "SpecialtyId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_id_speciality",
                table: "Appointments",
                newName: "IX_Appointments_SpecialtyId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_id_professional",
                table: "Appointments",
                newName: "IX_Appointments_ProfessionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Professionals_ProfessionalId",
                table: "Appointments",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Specialties_SpecialtyId",
                table: "Appointments",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
