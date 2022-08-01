using CodeFirst;

Carrera carrera = new Carrera();
carrera.NombreCarrera = "INGENIERIA EN SISTEMAS COMPUTACIONALES";
carrera.Plan = "2018";
carrera.Activa = true;
using (CodeFirstContext contexto = new CodeFirstContext())
{
    contexto.Carreras.Add(carrera);
    contexto.SaveChanges();
}
Console.WriteLine("Se agrego una carrera");