using System;
using System.Web.Mvc;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.ViewModels.Login;
using ProntuarioUnico.AuxiliaryClasses;
using AutoMapper;

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
            ViewBag.NovoUsuario = new NovoUsuarioViewModel();

            return View();
        }

        [HttpPost]
        public ActionResult Logar(LoginViewModel usuario)
        {
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
                    }
                }
            }

            return Json("CPF ou senha inválidos.");
        }

        [HttpPost]
        public ActionResult Cadastrar(NovoUsuarioViewModel novoUsuario)
        {
            if (novoUsuario.Valido())
            {
                if (Utils.CPFValido(novoUsuario.CPF))
                {
                    if (!this.PessoaFisicaRepository.CPFExistente(novoUsuario.CPF.Trim().Replace(".", "").Replace("-", "")))
                    {
                        PessoaFisica novaPessoaFisica = Mapper.Map<NovoUsuarioViewModel, PessoaFisica>(novoUsuario);
                        novaPessoaFisica.CPF = novaPessoaFisica.CPF.Trim().Replace(".", "").Replace("-", "");
                        novaPessoaFisica.Senha = Utils.Base64Encode(novaPessoaFisica.Senha);

                        this.PessoaFisicaRepository.Cadastrar(novaPessoaFisica);

                        return RedirectToAction("Login", "Login");
                    }
                    else
                    {
                        return Json("Já existe uma pessoa cadastrada com o CPF informado.");
                    }
                }
                else
                {
                    return Json("CPF inválido.");
                }
            }
            else
            {
                return Json("Existem campos obrigatórios que não foram cadastrados.");
            }
        }

        [HttpPost]
        public ActionResult RecuperarAcesso(String cpf)
        {
            PessoaFisica pessoa = this.PessoaFisicaRepository.Obter(cpf);

            if (pessoa == default(PessoaFisica))
                return Json("CPF informado não encontrado.");

            string codigo = Utils.GenerateRandomNumber();
            string codigoBase64 = Utils.Base64Encode(codigo);

            pessoa.Senha = codigoBase64;
            this.PessoaFisicaRepository.Alterar(pessoa);

            Utils.SendEmail(pessoa.Email, $"Olá, {pessoa.Nome}. Foi realizada a alteração da sua senha anterior. A nova senha é : {codigo}. Você pode realizar o login e alterar sua senha a área de cadastro.", "Recuperação de Senha - Nova senha gerada");

            return RedirectToAction("Login", "Login");
        }
    }
}