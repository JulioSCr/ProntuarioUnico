using ProntuarioUnico.Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Data.Context.EntityConfig
{
    public class TipoDocumentoConfig : EntityTypeConfiguration<TipoDocumento>
    {
        public TipoDocumentoConfig()
        {
            ToTable("TIPO_DOCUMENTO", "DBO");
            HasKey(p => p.Codigo);
            Property(p => p.Codigo).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Codigo).HasColumnName("CD_TIPO_DOCUMENTO");
            Property(p => p.Descricao).HasColumnName("DS_TIPO_DOCUMENTO");
        }
    }
}
