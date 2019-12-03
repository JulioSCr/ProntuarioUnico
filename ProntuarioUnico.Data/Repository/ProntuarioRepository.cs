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
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly ProntuarioUnicoContext Context;

        public ProntuarioRepository()
        {
            this.Context = new ProntuarioUnicoContext();
        }

        public List<Prontuario> Listar(int codigo)
        {
            return this.Context.Prontuarios.Where(_ => _.CodigoPessoaFisica == codigo).ToList();
        }
    }
}
