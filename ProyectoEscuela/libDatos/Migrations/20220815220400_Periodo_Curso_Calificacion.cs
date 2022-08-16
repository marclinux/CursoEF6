using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libDatos.Migrations
{
    public partial class Periodo_Curso_Calificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Periodos",
                schema: "dbo",
                columns: table => new
                {
                    PeriodoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Semestre = table.Column<int>(type: "int", nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodos", x => x.PeriodoId);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                schema: "dbo",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PeriodoId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                    table.ForeignKey(
                        name: "FK_Cursos_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalSchema: "dbo",
                        principalTable: "Materias",
                        principalColumn: "MateriaId");
                    table.ForeignKey(
                        name: "FK_Cursos_Periodos_PeriodoId",
                        column: x => x.PeriodoId,
                        principalSchema: "dbo",
                        principalTable: "Periodos",
                        principalColumn: "PeriodoId");
                });

            migrationBuilder.CreateTable(
                name: "Calificaciones",
                schema: "dbo",
                columns: table => new
                {
                    CalificacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    AlumnoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificaciones", x => x.CalificacionId);
                    table.ForeignKey(
                        name: "FK_Calificaciones_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalSchema: "dbo",
                        principalTable: "Alumnos",
                        principalColumn: "AlumnoId");
                    table.ForeignKey(
                        name: "FK_Calificaciones_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalSchema: "dbo",
                        principalTable: "Cursos",
                        principalColumn: "CursoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_AlumnoId",
                schema: "dbo",
                table: "Calificaciones",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_CursoId",
                schema: "dbo",
                table: "Calificaciones",
                column: "CursoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_MateriaId",
                schema: "dbo",
                table: "Cursos",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_PeriodoId",
                schema: "dbo",
                table: "Cursos",
                column: "PeriodoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calificaciones",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cursos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Periodos",
                schema: "dbo");
        }
    }
}
