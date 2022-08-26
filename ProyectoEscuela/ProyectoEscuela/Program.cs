using libDatos.Repositorios;
using libDatos;
using Microsoft.EntityFrameworkCore;
using ProyectoEscuela;
using libDatos.Negocios;

int opcion = 0;
bool valida = false;
var optionBuilder = new DbContextOptionsBuilder<ContextoEscuela>();
optionBuilder.UseSqlServer("Server=.\\sqlexpress2016;" +
    "Database=escuelaCF;Trusted_Connection=True;");
using (ContextoEscuela bd = new ContextoEscuela(optionBuilder.Options))
{
    do
    {
        Console.WriteLine("Menú Principal");
        Console.WriteLine("1. Carreras");
        Console.WriteLine("2. Mostrar alumnos inscritos");
        Console.WriteLine("3. Mostrar periodos");
        Console.WriteLine("4. Mostrar calificaciones");
        Console.WriteLine("5. Mostrar materias relacionadas");
        Console.WriteLine("6. Mostrar promedios");
        Console.WriteLine("7. Agrega periodo");
        Console.WriteLine("20. Salir");
        do
        {
            valida = int.TryParse(Console.ReadLine(), out opcion);
        } while (!valida || opcion < 1 || opcion > 20);
        switch (opcion)
        {
            case 1:
                OpcionesMenu.MenuCarreras(bd);
                break;
            case 2:
                AlumnoRepositorio repoAlumno = new AlumnoRepositorio(bd);
                List<Alumno> alumnos = repoAlumno.ObtenTodos(1);
                MuestraListaAlumnos(alumnos);
                break;
            case 3:
                PeriodoRepositorio repoPeriodo = new PeriodoRepositorio(bd);
                List<Periodo> periodos = repoPeriodo.ObtenTodos();
                MuestraListaPeriodos(periodos);
                break;
            case 4:
                repoAlumno = new AlumnoRepositorio(bd);
                alumnos = repoAlumno.ObtenTodos(1);
                MuestraListaAlumnos(alumnos);
                Console.WriteLine("Selecciona el indice del alumno:");
                int indice = Convert.ToInt32(Console.ReadLine());
                repoPeriodo = new PeriodoRepositorio(bd);
                periodos = repoPeriodo.ObtenTodos();
                MuestraListaPeriodos(periodos);
                Console.WriteLine("Selecciona el indice del periodo:");
                int indicePeriodo = Convert.ToInt32(Console.ReadLine());
                CalificacionRepositorio repoCalificacion = 
                    new CalificacionRepositorio(bd);
                clsAlumnoCalificaciones alumno = new clsAlumnoCalificaciones();
                alumno = repoCalificacion.Obten(alumnos[indice].AlumnoId,
                                                periodos[indicePeriodo].PeriodoId);
                Console.WriteLine("nombre: " + alumno.NombreCompleto +
                                    " numero de control: " + alumno.NumeroControl);
                Console.WriteLine("Materia\t\t\tCalificacion\t\tValor");
                foreach (var item in alumno.Calificaciones)
                {
                    Console.WriteLine(item.NombreMateria + "\t" +
                                        item.NombreCalificacion + "\t\t" +
                                        item.Valor.ToString());
                }
                break;
            case 5:
                OpcionesMenu.MuestraMateriasDepende(bd);
                break;
            case 6:
                repoAlumno = new AlumnoRepositorio(bd);
                List<clsAlumnoPromedio> alumnosPromedio = new List<clsAlumnoPromedio>();
                alumnosPromedio = repoAlumno.ObtenConPromedio();
                foreach (var item in alumnosPromedio)
                {
                    Console.WriteLine("nombre: " + item.NombreCompleto +
                    " numero de control: " + item.NumeroControl + " " +
                    " promedio: " + item.Promedio.ToString());
                }
                break;
            case 7:
                repoPeriodo = new PeriodoRepositorio(bd);
                Periodo periodo = new Periodo();
                Console.WriteLine("Dame el semestre del periodo:");
                periodo.Semestre = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Dame el año del periodo:");
                periodo.Anio = Convert.ToInt32(Console.ReadLine());
                periodo.Nombre = periodo.Semestre.ToString() + "-" +
                    periodo.Anio.ToString();
                repoPeriodo.Agrega(periodo);
                break;
            default:
                break;
        }
    } while (opcion != 20);
}

void MuestraListaPeriodos(List<Periodo> periodos)
{
    Console.WriteLine("indice\t\tNombre\t\tSemestre\t\tAño");
    for (int i = 0; i < periodos.Count; i++)
    {
        Console.WriteLine(i.ToString() + " \t\t" + periodos[i].Nombre +
                            "\t\t" + periodos[i].Semestre.ToString() +
                            "\t\t" + periodos[i].Anio.ToString());
    }
}

void MuestraListaAlumnos(List<Alumno> alumnos)
{
    Console.WriteLine("indice\t\tNombre                       \t\tNumeroControl");
    for (int i = 0; i < alumnos.Count; i++)
    {
        Console.WriteLine(i.ToString() + "\t\t" + alumnos[i].Nombres +
            " " + alumnos[i].ApellidoPaterno + " " + alumnos[i].ApellidoMaterno +
            "\t\t" + alumnos[i].NumeroControl);
    }
}