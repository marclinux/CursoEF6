using libDatos.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos.Repositorios
{
    public class AlumnoRepositorio
    {
        #region Propiedades
        private ContextoEscuela _bd;
        #endregion

        #region Constructor
        public AlumnoRepositorio(ContextoEscuela contexto)
        {
            _bd = contexto;
        }
        #endregion

        #region Metodos
        public List<Alumno> ObtenTodos(int estatus)
        {
            List<Alumno> alumnos = new List<Alumno>();
            //alumnos = (_bd.Alumnos
            //            .Where(alm => (alm.Estatus == estatus)))
            //            .ToList();
            alumnos = (from alm in _bd.Alumnos
                       where alm.Estatus == estatus
                       select alm).ToList();
            return alumnos;
        }

        public List<clsAlumnoPromedio> ObtenConPromedio()
        {
            List<clsAlumnoPromedio> lista = new List<clsAlumnoPromedio>();
            lista = (from alm in _bd.Alumnos
                     join c2 in
                     (from cal in _bd.Calificaciones
                      group cal by cal.AlumnoId into rc
                      select new
                      {
                          AlumnoId = rc.Key,
                          Promedio = rc.Average(rc => rc.Valor)
                      })
                     on alm.AlumnoId equals c2.AlumnoId
                     select new clsAlumnoPromedio
                     {
                         AlumnoId = alm.AlumnoId,
                         Nombres = alm.Nombres,
                         ApellidoPaterno = alm.ApellidoPaterno,
                         ApellidoMaterno = alm.ApellidoMaterno,
                         NumeroControl = alm.NumeroControl,
                         Promedio = Math.Round(c2.Promedio, 2)
                     }).ToList();
            return lista;
        }
        #endregion
    }
}
