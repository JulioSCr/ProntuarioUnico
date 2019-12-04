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
    public class EspecialidadeAtendimentoRepository : IEspecialidadeAtendimentoRepository
    {
        private readonly ProntuarioUnicoContext Context;

        public EspecialidadeAtendimentoRepository()
        {
            this.Context = new ProntuarioUnicoContext();
        }

        public List<EspecialidadeAtendimento> Listar()
        {
            return this.Context.EspecialidadesAtendimento.ToList();
        }
    }
}
