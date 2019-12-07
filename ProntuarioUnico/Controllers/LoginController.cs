using Newtonsoft.Json;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProntuarioUnico.Business.Interfaces.Business;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.ViewModels.Login;
using ProntuarioUnico.AuxiliaryClasses;

namespace ProntuarioUnico.Controllers
{
    public class LoginController : Controller
    {
        private readonly IPessoaFisicaRepository PessoaFisicaRepository;

        public LoginController(IPessoaFisicaRepository pessoaFisicaRepository)
        {
            this.PessoaFisicaRepository = pessoaFisicaRepository;
        }

        // GET: Login
        public ActionResult Login()
        {
            ViewBag.Usuario = new LoginViewModel();

            return View();
        }

        [HttpPost]
        public ActionResult Logar(LoginViewModel usuario)
        {
            usuario.CPF = "45816622811";
            usuario.Senha = "Cavalos123";

            if (usuario.Valido())
            {
                PessoaFisica pessoa = this.PessoaFisicaRepository.Obter(usuario.CPF);

                if (pessoa != default(PessoaFisica))
                {
                    String senhaBase64 = Utils.Base64Encode(usuario.Senha);

                    if (pessoa.Senha.Equals(senhaBase64))
                    {
                        UserAuthentication.Login(usuario.CPF, pessoa.Codigo);
                        return RedirectToAction("Index", "PessoaFisica");
                        //return RedirectToAction("Index", "Home");
                    }
                }
            }

            return Json("CPF ou senha inválidos.");
        }
    }
}