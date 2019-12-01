using Newtonsoft.Json;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProntuarioUnico.Controllers
{
    public class LoginController : Controller
    {
        private ProntuarioUnico.Global mobjGlobal = new ProntuarioUnico.Global();

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
                if (mobjGlobal.AutenticaUsuarioSenha(ref lexcMensagem, vstrCPF, vstrSenha) == false) {
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
    }
}