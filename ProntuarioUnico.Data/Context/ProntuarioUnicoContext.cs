using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Data.Context.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Data.Context
{
    public class ProntuarioUnicoContext : DbContext
    {
        public DbSet<PessoaFisica> Pessoas { get; set; }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PessoaFisicaConfig());
            modelBuilder.Configurations.Add(new TipoDocumentoConfig());

            Database.SetInitializer<ProntuarioUnicoContext>(null);
        }
    }
}
