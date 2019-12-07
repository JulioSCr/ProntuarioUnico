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
        private ProntuarioUnico.Global mobjGlobal = new ProntuarioUnico.Global();
        private readonly IPessoaFisicaRepository PessoaFisicaRepository;

        public LoginController(IPessoaFisicaRepository pessoaFisicaRepository)
        {
            this.PessoaFisicaRepository = pessoaFisicaRepository;
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Logar(String vstrCPF, String vstrSenha)
        {
            // Retorno
            object lobjException = null;
            // Objetos
            Exception lexcMensagem = null;
            try
            {
                if (mobjGlobal.AutenticaUsuarioSenha(ref lexcMensagem, vstrCPF, vstrSenha) == false)
                {
                    if (lexcMensagem != null)
                    {
                        throw lexcMensagem;
                    }
                    else
                    {
                        throw new Exception("Usuário ou senha inválidos");
                    }
                }
            }
            catch (Exception ex)
            {
                if (lexcMensagem == null) { lexcMensagem = ex; }
            }
            finally
            {
                if (lexcMensagem != null)
                {
                    lobjException = mobjGlobal.ConverterParaJson(mobjGlobal.CriarException(lexcMensagem, lexcMensagem.Message));
                    // Rollback
                }
                else
                {
                    // Commit
                }
                // Fechar conexão

                lexcMensagem = null;
            }

            return Json(
                new
                {
                    Exception = lobjException
                },
                "json"
            );
        }

        [HttpPost]
        public ActionResult Logar(LoginViewModel login)
        {
            if (login.Valido())
            {
                PessoaFisica pessoa = this.PessoaFisicaRepository.Obter(login.CPF);

                if (pessoa != default(PessoaFisica))
                {
                    String senhaBase64 = Utils.Base64Encode(login.Senha);
                    String senhaBanco = Utils.Base64Decode(pessoa.Senha);

                    if (pessoa.Senha.Equals(senhaBase64) && senhaBanco.Equals(pessoa.Senha))
                    {
                        UserAuthentication.Login(login.CPF, pessoa.Codigo);
                        return View("Home", "Index");
                    }
                }
            }

            return Json("CPF ou senha inválidos.");
        }
    }
}