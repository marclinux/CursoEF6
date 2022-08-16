using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos
{
    [Table("Periodos", Schema = "dbo")]
    public class Periodo
    {
        #region Propiedades
        public int PeriodoId { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        public int Semestre { get; set; }
        public int Anio { get; set; }
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        #endregion
    }
}
