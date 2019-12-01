using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Entities
{
    public class PessoaFisica
    {
        public long Codigo { get; set; }
        public String Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public String DescricaoTelefone { get; set; }
        public long CodigoTipoDocumento { get; set; }
        public long NumeroDocumento { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAtualizacao { get; set; }

        internal PessoaFisica()
        {

        }
    }
}
