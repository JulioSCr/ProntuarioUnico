using ProntuarioUnico.Business.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Entities
{
    public class PessoaFisica : BaseEntity
    {
        public long Codigo { get; set; }
        public String Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public String NumeroTelefone { get; set; }
        public String CPF { get; set; }
        public String Senha { get; set; }

        internal PessoaFisica()
        {

        }

        public PessoaFisica(string nome, DateTime dataNascimento, string numeroTelefone, string cPF, string senha)
        {
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.NumeroTelefone = numeroTelefone;
            this.CPF = cPF;
            this.Senha = senha;
            this.Ativo = true;
            this.DataAtualizacao = DateTime.Now;
        }

        public void Alterar(string cPF, DateTime dataNascimento, string nome, string numeroTelefone, string senha)
        {
            this.CPF = cPF;
            this.DataNascimento = dataNascimento;
            this.Nome = nome;
            this.NumeroTelefone = numeroTelefone;
            this.Senha = senha;
            this.Ativo = true;
            this.DataAtualizacao = DateTime.Now;
        }
    }
}