using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Data.Repository
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly ProntuarioUnicoContext Context;

        public AtendimentoRepository()
        {
            this.Context = new ProntuarioUnicoContext();
        }
    }
}
