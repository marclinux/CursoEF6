using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos
{
    public class ContextoEscuela : DbContext
    {
        #region Propiedades
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        #endregion

        #region Constructor
        public ContextoEscuela(DbContextOptions<ContextoEscuela> options)
            : base(options)
        {

        }
        #endregion

        #region Metodos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materia>()
                .HasOne(m => m.oCarrera)
                .WithMany(c => c.Materias)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Alumno>()
                .HasOne(a => a.oCarrera)
                .WithMany(c => c.Alumnos)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Curso>()
                .HasOne(c => c.oPeriodo)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Curso>()
                .HasOne(c => c.oMateria)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.oCurso)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.oAlumno)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            Carrera[] carreras =
            {
                new Carrera {CarreraId = 1, NombreCarrera = "SIN CARRERA",
                    Activa = true, Plan = "", SemestreInicial = 0, SemestreFinal = 0}
                , new Carrera {CarreraId = 2,
                    NombreCarrera = "TRONCO COMUN ADMINISTRATIVO",
                    Activa = true, Plan = "2018", SemestreInicial = 1, SemestreFinal  = 3}
                , new Carrera {CarreraId = 3, 
                    NombreCarrera = "INGENIERIA EN SISTEMAS COMPUTACIONALES",
                    Activa = true, Plan = "2018", SemestreInicial = 1, SemestreFinal  = 9}
            };
            modelBuilder.Entity<Carrera>()
                .HasData(carreras);

            Materia[] materias =
            {
                new Materia { MateriaId = 1, 
                    NombreMateria = "CONTABILIDAD I", Activa = true
                , Semestre = 1, CarreraId = 2, MateriaDependeId = 0 }
                , new Materia { MateriaId = 2, 
                    NombreMateria  = "ADMINISTRACIÓN DE EMPRESAS I"
                , Activa = true, Semestre = 1, CarreraId= 2, MateriaDependeId = 0}
                , new Materia { MateriaId = 3, 
                    NombreMateria  = "INTRODUCCIÓN A LA PROGRAMACIÓN"
                , Activa = true, Semestre = 1, CarreraId= 3, MateriaDependeId = 0}
                , new Materia { MateriaId = 4, NombreMateria  = "MATEMATICAS DISCRETAS"
                , Activa = true, Semestre = 1, CarreraId= 3, MateriaDependeId = 0}
                , new Materia { MateriaId = 5, NombreMateria  = "PROGRAMACION I"
                , Activa = true, Semestre = 2, CarreraId= 3, MateriaDependeId = 3}
                , new Materia { MateriaId = 6, NombreMateria  = "ESTRUCTURA DE DATOS"
                , Activa = true, Semestre = 2, CarreraId= 3, MateriaDependeId = 0}
            };
            modelBuilder.Entity<Materia>()
                .HasData(materias);
            Alumno[] alumnos = {
                new Alumno {AlumnoId = 1, NumeroControl = "8001001", Nombres = "MARCOS JESUS",
                ApellidoPaterno = "HERNANDEZ", ApellidoMaterno = "HERNANDEZ", CarreraId = 3,
                 Estatus = 1, SemestreActual = 1},
                new Alumno { AlumnoId = 2, NumeroControl = "8001002", Nombres = "PEDRO",
                ApellidoPaterno = "PEREZ", ApellidoMaterno = "GARCIA", CarreraId = 1,
                 Estatus = 0, SemestreActual = 0} };
            modelBuilder.Entity<Alumno>()
                .HasData(alumnos);
            Periodo[] periodos =
            {
                new Periodo{PeriodoId = 1, Semestre = 1, Anio = 2022, Nombre = "01-2022"}
            };
            modelBuilder.Entity<Periodo>()
                .HasData(periodos);
            Curso[] cursos =
            {
                new Curso { CursoId = 1, PeriodoId = 1, 
                    Nombre = "INTR-01-2022", MateriaId = 3 }
                , new Curso { CursoId = 2, PeriodoId = 1, 
                    Nombre = "MATE-01-2022", MateriaId = 4 }
            };
            modelBuilder.Entity<Curso>()
                .HasData(cursos);
            Calificacion[] calificaciones =
            {
                new Calificacion{CalificacionId = 1, CursoId = 1, AlumnoId = 1
                    , Nombre = "FINAL", Valor = 5.0M}
                , new Calificacion{CalificacionId = 2, CursoId = 2, AlumnoId = 1
                    , Nombre = "FINAL", Valor = 9.5M}
            };
            modelBuilder.Entity<Calificacion>()
                .HasData(calificaciones);

        }
        #endregion
    }
}
