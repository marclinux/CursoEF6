using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos
{
    [Table("Carreras", Schema="dbo")]
    public class Carrera
    {
        #region Propiedades
        public int CarreraId { get; set; }
        [MaxLength(500), Required]
        public string NombreCarrera { get; set; }
        [MaxLength(20), Required]
        public string Plan { get; set; }
        public bool Activa { get; set; }
        public ICollection<Materia> Materias { get; set; }
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        #endregion
    }
}
