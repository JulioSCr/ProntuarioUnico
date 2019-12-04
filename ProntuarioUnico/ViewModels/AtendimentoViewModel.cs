using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.ViewModels
{
    public class AtendimentoViewModel
    {
        public Int32 IdEspecialidade { get; set; }
        public Int32 CodigoMedico { get; set; }
        public String Observacao { get; set; }

        internal AtendimentoViewModel()
        {

        }
    }
}