using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos.Negocios
{
    public class clsAlumnoCalificaciones
    {
        #region Propiedades
        public int AlumnoId { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NumeroControl { get; set; }
        public List<clsCalificaciones> Calificaciones { get; set; }
        public string NombreCompleto
        {
            get { return Nombres + " " + ApellidoPaterno + " " + 
                    ApellidoMaterno; }
        }
        #endregion

        #region Constructor
        public clsAlumnoCalificaciones()
        {
            Calificaciones = new List<clsCalificaciones>();
        }
        #endregion

        #region Metodos
        #endregion
    }
}
