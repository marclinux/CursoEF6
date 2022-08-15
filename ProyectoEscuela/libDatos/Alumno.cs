using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos
{
    [Table("Alumnos", Schema="dbo")]
    public class Alumno
    {
        #region Propiedades
        public int AlumnoId { get; set; }
        [MaxLength(30)]
        public string NumeroControl { get; set; }
        [MaxLength(200)]
        public string Nombres { get; set; }
        [MaxLength(200)]
        public string ApellidoPaterno { get; set; }
        [MaxLength(200)]
        public string ApellidoMaterno { get; set; }
        public int CarreraId { get; set; }
        public Carrera oCarrera { get; set; }
        public int SemestreActual { get; set; }
        public int Estatus { get; set; }
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        #endregion
    }
}
