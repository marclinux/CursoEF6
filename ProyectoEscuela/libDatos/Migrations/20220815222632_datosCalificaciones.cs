using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace libDatos.Migrations
{
    public partial class datosCalificaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Carreras",
                columns: new[] { "CarreraId", "Activa", "NombreCarrera", "Plan", "SemestreFinal", "SemestreInicial" },
                values: new object[,]
                {
                    { 1, true, "SIN CARRERA", "", 0, 0 },
                    { 2, true, "TRONCO COMUN ADMINISTRATIVO", "2018", 3, 1 },
                    { 3, true, "INGENIERIA EN SISTEMAS COMPUTACIONALES", "2018", 9, 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Periodos",
                columns: new[] { "PeriodoId", "Anio", "Nombre", "Semestre" },
                values: new object[] { 1, 2022, "01-2022", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Alumnos",
                columns: new[] { "AlumnoId", "ApellidoMaterno", "ApellidoPaterno", "CarreraId", "Estatus", "Nombres", "NumeroControl", "SemestreActual" },
                values: new object[,]
                {
                    { 1, "HERNANDEZ", "HERNANDEZ", 3, 1, "MARCOS JESUS", "8001001", 1 },
                    { 2, "GARCIA", "PEREZ", 1, 0, "PEDRO", "8001002", 0 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Materias",
                columns: new[] { "MateriaId", "Activa", "CarreraId", "MateriaDependeId", "NombreMateria", "Semestre" },
                values: new object[,]
                {
                    { 1, true, 2, 0, "CONTABILIDAD I", 1 },
                    { 2, true, 2, 0, "ADMINISTRACIÓN DE EMPRESAS I", 1 },
                    { 3, true, 3, 0, "INTRODUCCIÓN A LA PROGRAMACIÓN", 1 },
                    { 4, true, 3, 0, "MATEMATICAS DISCRETAS", 1 },
                    { 5, true, 3, 3, "PROGRAMACION I", 2 },
                    { 6, true, 3, 0, "ESTRUCTURA DE DATOS", 2 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Cursos",
                columns: new[] { "CursoId", "MateriaId", "Nombre", "PeriodoId" },
                values: new object[] { 1, 3, "INTR-01-2022", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Cursos",
                columns: new[] { "CursoId", "MateriaId", "Nombre", "PeriodoId" },
                values: new object[] { 2, 4, "MATE-01-2022", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Calificaciones",
                columns: new[] { "CalificacionId", "AlumnoId", "CursoId", "Nombre", "Valor" },
                values: new object[] { 1, 1, 1, "FINAL", 5.0m });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Calificaciones",
                columns: new[] { "CalificacionId", "AlumnoId", "CursoId", "Nombre", "Valor" },
                values: new object[] { 2, 1, 2, "FINAL", 9.5m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Alumnos",
                keyColumn: "AlumnoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Calificaciones",
                keyColumn: "CalificacionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Calificaciones",
                keyColumn: "CalificacionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Materias",
                keyColumn: "MateriaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Materias",
                keyColumn: "MateriaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Materias",
                keyColumn: "MateriaId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Materias",
                keyColumn: "MateriaId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Alumnos",
                keyColumn: "AlumnoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Carreras",
                keyColumn: "CarreraId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Carreras",
                keyColumn: "CarreraId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Materias",
                keyColumn: "MateriaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Materias",
                keyColumn: "MateriaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Periodos",
                keyColumn: "PeriodoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Carreras",
                keyColumn: "CarreraId",
                keyValue: 3);
        }
    }
}
