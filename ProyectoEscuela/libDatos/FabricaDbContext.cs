using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDatos
{
    public class FabricaDbContext : IDesignTimeDbContextFactory<ContextoEscuela>
    {
        #region Propiedades
        #endregion

        #region Constructor
        #endregion

        #region Metodos
        public ContextoEscuela CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextoEscuela>();
            optionsBuilder.UseSqlServer(
                "Server=.\\sqlexpress2016;Database=EscuelaCF;Trusted_Connection=True");
            return new ContextoEscuela(optionsBuilder.Options);

        }
        #endregion
    }
}
