using libDatos.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos.Repositorios
{
    public class MateriaRepositorio
    {
        #region Propiedades
        private ContextoEscuela _bd;
        #endregion

        #region Constructor
        public MateriaRepositorio(ContextoEscuela contexto)
        {
            _bd = contexto;
        }
        #endregion

        #region Metodos
        public List<clsMateriasDepende> ObtenRelacionadas(int CarreraId)
        {
            List<clsMateriasDepende> lista = new List<clsMateriasDepende>();
            lista = (from mat in _bd.Materias
                     join mat2 in _bd.Materias
                     on mat.MateriaDependeId equals mat2.MateriaId into relm
                     from mat3 in relm.DefaultIfEmpty()
                     where mat.CarreraId == CarreraId
                     select new clsMateriasDepende
                     {
                         MateriaId = mat.MateriaId,
                         NombreMateria = mat.NombreMateria,
                         Semestre = mat.Semestre,
                         MateriaIdDepende = (mat3.MateriaId == null) ? 0 : mat3.MateriaId,
                         NombreMateriaDepende = (mat3.NombreMateria == null) ? "" :
                                                 mat3.NombreMateria,
                         SemestreMateriaDepende = (mat3.Semestre == null) ? 0 : mat3.Semestre
                     }).ToList();
            return lista;
        }
        #endregion
    }
}
