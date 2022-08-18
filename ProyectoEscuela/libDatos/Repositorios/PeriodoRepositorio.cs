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
