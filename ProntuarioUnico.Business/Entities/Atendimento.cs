using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Entities
{
    public class Atendimento
    {
        public Int32 NumeroAtendimento{ get; set; }
        public Int32 CodigoPessoaFisica { get; set; }
        public Int32 CrmMedico { get; set; }
        public Int32 CodigoTipoAtendimento { get; set; }
        public Int32 CodigoEspecialidade { get; set; }
        public DateTime DataAtendimento { get; set; }
        public String DescricaoObservacao { get; set; }

        internal Atendimento()
        {

        }
    }
}
