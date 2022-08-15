using libDatos.Repositorios;
using libDatos;
using Microsoft.EntityFrameworkCore;
using ProyectoEscuela;

int opcion = 0;
bool valida = false;
var optionBuilder = new DbContextOptionsBuilder<ContextoEscuela>();
optionBuilder.UseSqlServer("Server=.\\sqlexpress2016;" +
    "Database=escuelaCF;Trusted_Connection=True;");
using (ContextoEscuela bd = new ContextoEscuela(optionBuilder.Options))
{
    do
    {
        Console.WriteLine("Menú Carreras");
        Console.WriteLine("1. Carreras");
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
            default:
                break;
        }
    } while (opcion != 20);
}