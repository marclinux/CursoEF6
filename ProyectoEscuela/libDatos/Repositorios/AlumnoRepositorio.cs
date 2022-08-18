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
        #endregion
    }
}
