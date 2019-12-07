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
        public static StatusLogin Login(string cpf, long codigoPessoaFisica)
        {
            FormsAuthentication.SetAuthCookie(cpf, true);
            HttpContext.Current.Session["usuario"] = cpf;
            HttpContext.Current.Session["codigo_pessoa_fisica"] = Convert.ToString(codigoPessoaFisica);

            return StatusLogin.Sucesso;
        }

        public static StatusLogin Logoff()
        {
            HttpContext.Current.Session.Clear();
            FormsAuthentication.SignOut();

            return StatusLogin.Out;
        }

        public static string ObterCodigoPessoaFisicaLogada()
        {
            string login = Convert.ToString(HttpContext.Current.Session["codigo_pessoa_fisica"]);
            return login;
        }
    }
}