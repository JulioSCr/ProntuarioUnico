using ProntuarioUnico.Business.Entities.Enums;
using ProntuarioUnico.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ProntuarioUnico.AuxiliaryClasses
{
    public static class UserAuthentication
    {
        public static StatusLogin Login(string login, long codigoInterno)
        {
            FormsAuthentication.SetAuthCookie(login, true);
            HttpContext.Current.Session["usuario"] = login;
            HttpContext.Current.Session["codigo_identificacao"] = Convert.ToString(codigoInterno);

            return StatusLogin.Sucesso;
        }

        public static StatusLogin Logoff()
        {
            HttpContext.Current.Session.Clear();
            FormsAuthentication.SignOut();

            return StatusLogin.Out;
        }

        public static string ObterCodigoInternoUsuarioLogado()
        {
            string login = Convert.ToString(HttpContext.Current.Session["codigo_identificacao"]);
            return login;
        }
    }
}