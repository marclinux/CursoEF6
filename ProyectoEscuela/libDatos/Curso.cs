using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos
{
    [Table("Cursos", Schema = "dbo")]
    public class Curso
    {
        #region Propiedades
        public int CursoId { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        public int PeriodoId { get; set; }
        public Periodo oPeriodo { get; set; }
        public int MateriaId { get; set; }
        public Materia oMateria { get; set; }
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        #endregion
    }
}
