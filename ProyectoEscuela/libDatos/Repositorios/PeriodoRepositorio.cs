using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos.Repositorios
{
    public class PeriodoRepositorio
    {
        #region Propiedades
        private ContextoEscuela _bd;
        #endregion

        #region Constructor
        public PeriodoRepositorio(ContextoEscuela contexto)
        {
            _bd = contexto;
        }
        #endregion

        #region Metodos
        public void Agrega(Periodo periodo)
        {
            var materiasNuevas =
                (from al in (from alm in _bd.Alumnos
                             join car in _bd.Carreras
                             on alm.CarreraId equals car.CarreraId
                             where (alm.SemestreActual + 1)
                             >= car.SemestreInicial &&
                             (alm.SemestreActual + 1)
                             <= car.SemestreFinal && alm.Estatus == 1
                             select new
                             {
                                 alm.AlumnoId,
                                 alm.SemestreActual,
                                 alm.CarreraId
                             })
                 join mat in _bd.Materias
                 on new { Semestre = al.SemestreActual + 1, CarreraId = al.CarreraId }
                 equals new { Semestre = mat.Semestre, CarreraId = mat.CarreraId }
                 join crep in (from cur in _bd.Cursos
                               join cal in _bd.Calificaciones
                               on cur.CursoId equals cal.CursoId
                               where cal.Valor < 6.0m
                               select new
                               {
                                   cal.AlumnoId,
                                   cal.Valor,
                                   cur.MateriaId
                               })
                 on new { AlumnoId = al.AlumnoId, 
                     MateriaDependeId = mat.MateriaDependeId }
                 equals new { AlumnoId = crep.AlumnoId, 
                     MateriaDependeId = crep.MateriaId }
                         into rc
                 from rel in rc.DefaultIfEmpty()
                 where rel.Valor == null
                 orderby mat.MateriaId, al.AlumnoId
                 select new
                 {
                     AlumnoId = al.AlumnoId,
                     MateriaId = mat.MateriaId,
                     mat.MateriaDependeId,
                     mat.NombreMateria
                 }).ToList();
            using var transaccion = _bd.Database.BeginTransaction();
            _bd.Periodos.Add(periodo);
            _bd.SaveChanges();
            int materiaIdAnterior = 0;
            Curso curso = new Curso();
            foreach (var item in materiasNuevas)
            {
                if(materiaIdAnterior != item.MateriaId)
                {
                    curso = new Curso();
                    curso.PeriodoId = periodo.PeriodoId;
                    curso.Nombre = item.NombreMateria.Substring(0, 3) + "_" +
                                    periodo.Nombre;
                    curso.MateriaId = item.MateriaId;
                    _bd.Cursos.Add(curso);
                    _bd.SaveChanges();
                }
                Calificacion calificacion = new Calificacion();
                calificacion.CursoId = curso.CursoId;
                calificacion.Nombre = "FINAL";
                calificacion.AlumnoId = item.AlumnoId;
                calificacion.Valor = 0m;
                _bd.Calificaciones.Add(calificacion);
                _bd.SaveChanges();
                materiaIdAnterior = item.MateriaId;
                Alumno alumno = _bd.Alumnos.Find(item.AlumnoId);
                alumno.SemestreActual++;
                _bd.SaveChanges();
            }
            transaccion.Commit();
        }
        public List<Periodo> ObtenTodos()
        {
            List<Periodo> list = new List<Periodo>();
            //var conPeriodos = _bd.Periodos
            //                .Select(pe => pe)
            //                .OrderBy(pe => pe.Anio)
            //                .ThenBy(pe => pe.Semestre);

            var conPeriodos = from pe in _bd.Periodos 
                             orderby pe.Anio, pe.Semestre
                             select pe;
            list = conPeriodos.ToList();
            return list;
        }
        #endregion
    }
}
