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
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        private readonly ProntuarioUnicoContext Context;

        public TipoDocumentoRepository()
        {
            this.Context = new ProntuarioUnicoContext();
        }

        public List<TipoDocumento> Listar()
        {
            return this.Context.TiposDocumento.ToList();
        }
    }
}
