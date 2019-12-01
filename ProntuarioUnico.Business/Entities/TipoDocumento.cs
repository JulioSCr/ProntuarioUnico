using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Entities
{
    public class TipoDocumento
    {
        public Int32 Codigo { get; set; }
        public String Descricao { get; set; }

        internal TipoDocumento()
        {

        }
    }
}
