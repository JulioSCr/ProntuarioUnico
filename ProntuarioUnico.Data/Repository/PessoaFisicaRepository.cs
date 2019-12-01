using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Data.Repository
{
    public class PessoaFisicaRepository : IPessoaFisicaRepository
    {
        private readonly ProntuarioUnicoContext Context;

        public PessoaFisicaRepository()
        {
            this.Context = new ProntuarioUnicoContext();
        }

        public List<PessoaFisica> Listar()
        {
            return this.Context.Pessoas.ToList();
        }
    }
}
