using ProntuarioUnico.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Interfaces.Data
{
    public interface ITipoDocumentoRepository
    {
        List<TipoDocumento> Listar();
    }
}
