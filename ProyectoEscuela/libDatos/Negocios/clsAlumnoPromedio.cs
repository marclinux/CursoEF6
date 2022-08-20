using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos.Negocios
{
    public class clsAlumnoPromedio
    {
        #region Propiedades
        public int AlumnoId { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NumeroControl { get; set; }
        public decimal Promedio { get; set; }
        public string NombreCompleto
        {
            get
            {
                return Nombres + " " + ApellidoPaterno + " " +
                    ApellidoMaterno;
            }
        }
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        #endregion
    }
}
