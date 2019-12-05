using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProntuarioUnico.Filters
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        //public string[] Permissoes_Requeridas { get; set; }

        //private IPermissoes PermissoesSistema { get; set; }

        //void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    PermissoesSistema = Injector.Injector.GetInstance<IPermissoes>();

        //    if (SessionAtiva())
        //    {
        //        //SE NÃO TIVER PERMISSÃO, REDIRECIONA PARA O MENU PRINCIPAL.
        //        if (Permissoes_Requeridas != null)
        //        {
        //            if (!PossuiPermissao(Permissoes_Requeridas))
        //            {
        //                filterContext.Result = new StatusRedirectResult(
        //                    new RouteValueDictionary
        //                    {
        //                        {
        //                            "controller", "MenuPrincipal"
        //                        },
        //                        {
        //                            "action", "MenuPrincipal"
        //                        }
        //                    },
        //                    HttpStatusCode.Forbidden
        //                );
        //            }
        //        }

        //        // ADICIONA EVENTO DE ESCONDER BOTÃO NA PÁGINA DE MENUS.
        //        filterContext.Controller.ViewBag.Administrador = PossuiPermissao(new string[] { "ADMINISTRADOR" });
        //    }
        //    else
        //    {
        //        filterContext.Result = new StatusRedirectResult(
        //            new RouteValueDictionary
        //            {
        //                    {
        //                        "controller", "Login"
        //                    },
        //                    {
        //                        "action", "Login"
        //                    }
        //            },
        //            HttpStatusCode.Unauthorized
        //        );
        //    }
        //}

        //private bool PossuiPermissao(string[] permissoes_requeridas)
        //{
        //    int[] permissoes_usuario = HttpContext.Current.Session["permissoes"] as int[];

        //    foreach (string permissao_descricao in permissoes_requeridas)
        //    {
        //        if (permissoes_usuario.Contains(this.PermissoesSistema.Grupos[permissao_descricao]))
        //            return true;
        //    }

        //    return false;
        //}

        //private bool SessionAtiva()
        //{
        //    string usuario = Convert.ToString(HttpContext.Current.Session["usuario"]);
        //    return !string.IsNullOrEmpty(usuario);
        //}
    }
}
