using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProntuarioUnico.Business.Entities;

namespace ProntuarioUnico.Business.Interfaces.Data
{
    public interface IPessoaFisicaRepository
    {
        List<PessoaFisica> Listar();
    }
}
