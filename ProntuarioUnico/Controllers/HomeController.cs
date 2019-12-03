using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProntuarioUnico.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProntuarioRepository ProntuarioRepository;

        public HomeController(IProntuarioRepository prontuarioRepository)
        {
            this.ProntuarioRepository = prontuarioRepository;
        }

        public ActionResult Index()
        {
            int codigo = 0; // devemos receber o código da pessoa física referente a quem está logado para passar como parâmetro no método.

            List<Prontuario> prontuarios = this.ProntuarioRepository.Listar(codigo);
            return View(prontuarios);
        }
    }
}