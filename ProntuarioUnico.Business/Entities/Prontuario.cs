using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Entities
{
    public class Prontuario
    {
        public Int32 NumeroAtendimento { get; set; }
        public Int32 CodigoPessoaFisica { get; set; }
        public String TipoAtendimento { get; set; }
        public DateTime DataAtendimento { get; set; }
        public String NomeMedico { get; set; }
        public String Especialidade { get; set; }
        public String Observacoes { get; set; }

        internal Prontuario()
        {

        }
    }
}
