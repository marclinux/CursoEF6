using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libDatos.Migrations
{
    public partial class Alumno_ModCarreraMateria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MateriaDependeId",
                schema: "dbo",
                table: "Materias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Semestre",
                schema: "dbo",
                table: "Materias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SemestreFinal",
                schema: "dbo",
                table: "Carreras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SemestreInicial",
                schema: "dbo",
                table: "Carreras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Alumnos",
                schema: "dbo",
                columns: table => new
                {
                    AlumnoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroControl = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CarreraId = table.Column<int>(type: "int", nullable: false),
                    SemestreActual = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.AlumnoId);
                    table.ForeignKey(
                        name: "FK_Alumnos_Carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalSchema: "dbo",
                        principalTable: "Carreras",
                        principalColumn: "CarreraId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_CarreraId",
                schema: "dbo",
                table: "Alumnos",
                column: "CarreraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumnos",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "MateriaDependeId",
                schema: "dbo",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "Semestre",
                schema: "dbo",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "SemestreFinal",
                schema: "dbo",
                table: "Carreras");

            migrationBuilder.DropColumn(
                name: "SemestreInicial",
                schema: "dbo",
                table: "Carreras");
        }
    }
}
