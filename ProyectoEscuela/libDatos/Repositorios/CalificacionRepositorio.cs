using libDatos.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos.Repositorios
{
    public class CalificacionRepositorio
    {
        #region Propiedades
        private ContextoEscuela _bd;
        #endregion

        #region Constructor
        public CalificacionRepositorio(ContextoEscuela contexto)
        {
            _bd = contexto;
        }
        #endregion

        #region Metodos
        public clsAlumnoCalificaciones Obten(int alumnoId, int periodoId)
        {
            clsAlumnoCalificaciones alumno = new clsAlumnoCalificaciones();
            var listaResultado = (from alm in _bd.Alumnos join cal in _bd.Calificaciones
                                  on alm.AlumnoId equals cal.AlumnoId
                                  join cur in _bd.Cursos
                                  on cal.CursoId equals cur.CursoId
                                  join mat in _bd.Materias
                                  on cur.MateriaId equals mat.MateriaId
                                  where alm.AlumnoId == alumnoId 
                                  && cur.PeriodoId == periodoId
                                  select new
                                  {
                                      alm.AlumnoId,
                                      alm.NumeroControl,
                                      alm.Nombres,
                                      alm.ApellidoPaterno,
                                      alm.ApellidoMaterno,
                                      mat.NombreMateria,
                                      cal.Valor,
                                      cal.CalificacionId,
                                      cal.Nombre,
                                      cur.CursoId,
                                      mat.MateriaId,
                                      cur.PeriodoId
                                  }).ToList();
            bool inicio = true;
            foreach (var item in listaResultado)
            {
                if(inicio)
                {
                    alumno.AlumnoId = item.AlumnoId;
                    alumno.Nombres = item.Nombres;
                    alumno.ApellidoPaterno = item.ApellidoMaterno;
                    alumno.ApellidoMaterno = item.ApellidoPaterno;
                    alumno.NumeroControl = item.NumeroControl;
                    inicio = false;
                }
                clsCalificaciones calificacion = new clsCalificaciones();
                calificacion.CalificacionId = item.CalificacionId;
                calificacion.CursoId = item.CursoId;
                calificacion.MateriaId = item.MateriaId;
                calificacion.PeriodoId = item.PeriodoId;
                calificacion.NombreMateria = item.NombreMateria;
                calificacion.NombreCalificacion = item.Nombre;
                calificacion.Valor = item.Valor;
                alumno.Calificaciones.Add(calificacion);
            }
            return alumno;
        }
        #endregion
    }
}
