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
    public class PessoaFisicaConfig : EntityTypeConfiguration<PessoaFisica>
    {
        public PessoaFisicaConfig()
        {
            ToTable("PESSOA_FISICA", "DBO");
            HasKey(p => p.Codigo);
            Property(p => p.Codigo).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Codigo).HasColumnName("CD_PESSOA_FISICA");
            Property(p => p.Nome).HasColumnName("NM_PESSOA_FISICA");
            Property(p => p.DataNascimento).HasColumnName("DT_NASCIMENTO");
            Property(p => p.DescricaoTelefone).HasColumnName("DS_TELEFONE");
            Property(p => p.CodigoTipoDocumento).HasColumnName("CD_TIPO_DOCUMENTO");
            Property(p => p.NumeroDocumento).HasColumnName("VL_TIPO_DOCUMENTO");
            Property(p => p.Ativo).HasColumnName("IE_ATIVO");
            Property(p => p.DataAtualizacao).HasColumnName("DT_ATUALIZACAO");
        }
    }
}
