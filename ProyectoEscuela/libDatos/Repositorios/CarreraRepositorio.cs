using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos.Repositorios
{
    public class CarreraRepositorio : ICarreraRepositorio
    {
        #region Propiedades
        private ContextoEscuela _contexto;
        #endregion

        #region Constructor
        public CarreraRepositorio(ContextoEscuela contexto)
        {
            _contexto = contexto;
        }
        #endregion

        #region Metodos
        public void Agrega(Carrera carrera)
        {
            _contexto.Carreras.Add(carrera);
            _contexto.SaveChanges();
        }

        public void Elimina(int CarreraId)
        {
            Carrera carrera = _contexto.Carreras.Find(CarreraId);
            if(carrera != null)
            {
                _contexto.Carreras.Remove(carrera);
                _contexto.SaveChanges();
            }
        }

        public void Modifica(Carrera carrera)
        {
            Carrera carrera1 = _contexto.Carreras.Find(carrera.CarreraId);
            carrera1.NombreCarrera = carrera.NombreCarrera;
            carrera1.Plan = carrera.Plan;
            carrera1.SemestreInicial = carrera.SemestreInicial;
            carrera1.SemestreFinal = carrera.SemestreFinal;
            carrera1.Activa = carrera.Activa;
            _contexto.SaveChanges();
        }

        public Carrera Obten(int CarreraId, bool conMaterias)
        {
            Carrera carrera = _contexto.Carreras.Find(CarreraId);
            if (conMaterias)
                _contexto.Entry(carrera).Collection("Materias").Load();
            return carrera;
        }

        public List<Carrera> ObtenTodas()
        {
            return _contexto.Carreras.ToList();
        }
        #endregion
    }
}
