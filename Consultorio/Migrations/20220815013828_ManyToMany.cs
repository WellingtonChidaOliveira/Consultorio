using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessionalSpeciality");

            migrationBuilder.CreateTable(
                name: "tb_professional_speciality",
                columns: table => new
                {
                    id_professional = table.Column<int>(type: "int", nullable: false),
                    id_speciality = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_professional_speciality", x => new { x.id_speciality, x.id_professional });
                    table.ForeignKey(
                        name: "FK_tb_professional_speciality_Professionals_id_professional",
                        column: x => x.id_professional,
                        principalTable: "Professionals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_professional_speciality_Specialties_id_speciality",
                        column: x => x.id_speciality,
                        principalTable: "Specialties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_professional_speciality_id_professional",
                table: "tb_professional_speciality",
                column: "id_professional");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_professional_speciality");

            migrationBuilder.CreateTable(
                name: "ProfessionalSpeciality",
                columns: table => new
                {
                    ProfessionalsId = table.Column<int>(type: "int", nullable: false),
                    SpecialtiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalSpeciality", x => new { x.ProfessionalsId, x.SpecialtiesId });
                    table.ForeignKey(
                        name: "FK_ProfessionalSpeciality_Professionals_ProfessionalsId",
                        column: x => x.ProfessionalsId,
                        principalTable: "Professionals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessionalSpeciality_Specialties_SpecialtiesId",
                        column: x => x.SpecialtiesId,
                        principalTable: "Specialties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalSpeciality_SpecialtiesId",
                table: "ProfessionalSpeciality",
                column: "SpecialtiesId");
        }
    }
}
