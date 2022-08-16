using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos
{
    [Table("Calificaciones", Schema = "dbo")]
    public class Calificacion
    {
        #region Propiedades
        public int CalificacionId { get; set; }
        public string Nombre { get; set; }
        public decimal Valor { get; set; }
        public int CursoId { get; set; }
        public Curso oCurso { get; set; }
        public int AlumnoId { get; set; }
        public Alumno oAlumno { get; set; }
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        #endregion
    }
}
