using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos
{
    [Table("Materias", Schema = "dbo")]
    public class Materia
    {
        #region Propiedades
        public int MateriaId { get; set; }
        [MaxLength(500), Required]
        public string NombreMateria { get; set; }
        public bool Activa { get; set; }
        public int CarreraId { get; set; }
        public Carrera oCarrera { get; set; }
        public int Semestre { get; set; }
        public int MateriaDependeId { get; set; }
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        #endregion
    }
}
