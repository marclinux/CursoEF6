using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class CodeFirstContext : DbContext
    {
        #region Propiedades
        public DbSet<Carrera> Carreras { get; set; }
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\sqlexpress2016;Database=codefirst;Trusted_connection=true"); 
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Carrera>().ToTable("tblCarreras", schema: "dbo");
        //    modelBuilder.Entity<Carrera>()
        //        .Property(c => c.NombreCarrera).HasMaxLength(500);
        //    modelBuilder.Entity<Carrera>()
        //        .Property(c => c.NombreCarrera).IsRequired();
        //    modelBuilder.Entity<Carrera>()
        //        .Property(c => c.Plan).HasMaxLength(20);
        //    modelBuilder.Entity<Carrera>()
        //        .Property(c => c.Plan).IsRequired();
        //}
        #endregion
    }
}
