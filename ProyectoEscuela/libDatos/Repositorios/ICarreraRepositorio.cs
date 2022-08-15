using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos.Repositorios
{
    public interface ICarreraRepositorio
    {
        public void Agrega(Carrera carrera);
        public void Modifica(Carrera carrera);
        public void Elimina(int CarreraId);
        public Carrera Obten(int CarreraId, bool conMaterias);
        public List<Carrera> ObtenTodas();
    }
}
