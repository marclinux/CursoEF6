using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos
{
    public class ContextoEscuela : DbContext
    {
        #region Propiedades
        public DbSet<Carrera> Carreras { get; set; }
        #endregion

        #region Constructor
        public ContextoEscuela(DbContextOptions<ContextoEscuela> options)
            : base(options)
        {

        }
        #endregion

        #region Metodos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materia>()
                .HasOne(m => m.oCarrera)
                .WithMany(c => c.Materias)
                .OnDelete(DeleteBehavior.NoAction);
        }
        #endregion
    }
}
