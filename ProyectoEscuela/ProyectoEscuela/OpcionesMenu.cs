using libDatos;
using libDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEscuela
{
    public static class OpcionesMenu
    {
        #region Propiedades
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        public static void MenuCarreras(ContextoEscuela bd)
        {
            int opcion = 0;
            bool valida = false;
            int indice = 0;
            CarreraRepositorio repoCarrera = new CarreraRepositorio(bd);
            List<Carrera> Carreras = new List<Carrera>();
            do
            {
                Console.WriteLine("Menú Carreras");
                Console.WriteLine();
                Console.WriteLine("1. Agrega");
                Console.WriteLine("2. Modifica");
                Console.WriteLine("3. Elimina");
                Console.WriteLine("4. Agrega con materias");
                Console.WriteLine("5. Ver lista");
                Console.WriteLine("6. Ver una carrera con sus materias");
                Console.WriteLine("20. Salir");
                do
                {
                    valida = int.TryParse(Console.ReadLine(), out opcion);
                } while (!valida || opcion < 1 || opcion > 20);
                switch (opcion)
                {
                    case 1:
                        Carrera carrera = new Carrera();
                        PideDatos(carrera, false);
                        repoCarrera.Agrega(carrera);
                        break;
                    case 2:
                        Carreras = repoCarrera.ObtenTodas();
                        MuestraLista(Carreras);
                        Console.WriteLine("Dame el indice de la carrera a modificar:");
                        indice = Convert.ToInt32(Console.ReadLine());
                        carrera = new Carrera();
                        carrera = Carreras[indice];
                        PideDatos(carrera, true);
                        repoCarrera.Modifica(carrera);
                        break;
                    case 3:
                        Carreras = repoCarrera.ObtenTodas();
                        MuestraLista(Carreras);
                        Console.WriteLine("Dame el indice de la carrera a eliminar:");
                        indice = Convert.ToInt32(Console.ReadLine());
                        repoCarrera.Elimina(Carreras[indice].CarreraId);
                        break;
                    case 4:
                        carrera = new Carrera();
                        PideDatos(carrera, false);
                        carrera.Materias = new List<Materia>();
                        string nombreMateria = "";
                        do
                        {
                            Console.WriteLine("Dame el nombre de la materia:");
                            nombreMateria = Console.ReadLine();
                            if(nombreMateria != "")
                            {
                                Materia materia = new Materia();
                                materia.NombreMateria = nombreMateria;
                                Console.WriteLine("Dame el semestre de la materia:");
                                materia.Semestre = Convert.ToInt32(Console.ReadLine());
                                materia.MateriaDependeId = 0;
                                materia.Activa = true;
                                carrera.Materias.Add(materia);
                            }
                        } while (nombreMateria != "");
                        repoCarrera.Agrega(carrera);
                        break;
                    case 5:
                        Carreras = repoCarrera.ObtenTodas();
                        MuestraLista(Carreras);
                        break;
                    case 6:
                        Carreras = repoCarrera.ObtenTodas();
                        MuestraLista(Carreras);
                        Console.WriteLine("Dame el indice de la carrera a mostrar con sus materias:");
                        indice = Convert.ToInt32(Console.ReadLine());
                        carrera = repoCarrera.Obten(Carreras[indice].CarreraId, true);
                        Console.WriteLine("carrera: " + carrera.NombreCarrera);
                        foreach (Materia item in carrera.Materias)
                        {
                            Console.WriteLine("materia: " + item.NombreMateria);
                        }
                        break;
                    default:
                        break;
                }
            } while (opcion != 20);
        }

        private static void MuestraLista(List<Carrera> carreras)
        {
            for (int i = 0; i < carreras.Count; i++)
            {
                Console.WriteLine("indice: " + i.ToString() + " Nombre: " +
                                carreras[i].NombreCarrera);
            }
        }

        private static void PideDatos(Carrera carrera, bool pideActiva)
        {
            Console.WriteLine("Dame el nombre de la carrera:");
            carrera.NombreCarrera = Console.ReadLine();
            Console.WriteLine("Dame el plan de la carrera:");
            carrera.Plan = Console.ReadLine();
            Console.WriteLine("Dame el semestre de inicio de la carrera:");
            carrera.SemestreInicial = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dame el semestre final de la carrera:");
            carrera.SemestreFinal = Convert.ToInt32(Console.ReadLine());
            if (pideActiva)
            {
                Console.WriteLine("Dame si la carrera estará activa (true, false):");
                carrera.Activa = Convert.ToBoolean(Console.ReadLine());
            }
            else
                carrera.Activa = true;

        }
        #endregion
    }
}
