using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Business;
using ProntuarioUnico.Business.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProntuarioUnico.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPessoaFisicaBusiness PessoaFisicaBusiness;
        private readonly ITipoDocumentoRepository TipoDocumentoRepository;

        public HomeController(IPessoaFisicaBusiness pessoaFisicaBusiness, ITipoDocumentoRepository tipoDocumentoRepository)
        {
            this.PessoaFisicaBusiness = pessoaFisicaBusiness;
            this.TipoDocumentoRepository = tipoDocumentoRepository;
        }

        public ActionResult Index()
        {
            //List<PessoaFisica> pessoas = this.PessoaFisicaBusiness.Listar();
            //List<TipoDocumento> tiposDocumento = this.TipoDocumentoRepository.Listar();
            return View();
        }
    }
}