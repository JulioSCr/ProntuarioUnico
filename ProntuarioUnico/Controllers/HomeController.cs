using ProntuarioUnico.AuxiliaryClasses;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.ViewModels;
using System;
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
            string codigo = UserAuthentication.ObterCodigoInternoUsuarioLogado();

            List<Prontuario> prontuarios = this.ProntuarioRepository.Listar(Convert.ToInt32(codigo));
            ProntuarioViewModel model = new ProntuarioViewModel(prontuarios);

            return View(model);
        }
    }
}