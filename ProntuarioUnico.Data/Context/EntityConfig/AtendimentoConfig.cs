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
    public class AtendimentoConfig : EntityTypeConfiguration<Atendimento>
    {
        public AtendimentoConfig()
        {
            ToTable("ATENDIMENTO_PACIENTE", "DBO");
            HasKey(p => p.NumeroAtendimento);
            Property(p => p.NumeroAtendimento).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.NumeroAtendimento).HasColumnName("NR_ATENDIMENTO");
            Property(p => p.CodigoPessoaFisica).HasColumnName("CD_PESSOA_FISICA");
            Property(p => p.CrmMedico).HasColumnName("CRM_MEDICO");
            Property(p => p.CodigoTipoAtendimento).HasColumnName("ID_TIPO_ATENDIMENTO");
            Property(p => p.CodigoEspecialidade).HasColumnName("ID_ESPECIALIDADE");
            Property(p => p.DataAtendimento).HasColumnName("DT_ATENDIMENTO");
            Property(p => p.DescricaoObservacao).HasColumnName("DS_OBSERVACAO");
        }
    }
}
