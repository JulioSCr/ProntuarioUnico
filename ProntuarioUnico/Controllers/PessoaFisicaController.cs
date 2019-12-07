using AutoMapper;
using ProntuarioUnico.AuxiliaryClasses;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.ViewModels;
using System;
using System.Web.Mvc;

namespace ProntuarioUnico.Controllers
{
    public class PessoaFisicaController : Controller
    {
        private readonly IPessoaFisicaRepository PessoaFisicaRepository;

        public PessoaFisicaController(IPessoaFisicaRepository pessoaFisicaRepository)
        {
            this.PessoaFisicaRepository = pessoaFisicaRepository;
        }

        // GET: PessoaFisica
        public ActionResult Index()
        {
            string codigo = UserAuthentication.ObterCodigoPessoaFisicaLogada();

            PessoaFisica pessoa = this.PessoaFisicaRepository.Obter(Convert.ToInt32(codigo));
            PessoaFisicaViewModel viewModel = Mapper.Map<PessoaFisica, PessoaFisicaViewModel>(pessoa);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Atualizar(PessoaFisicaViewModel pessoaViewModel)
        {
            if (pessoaViewModel.Valido())
            {
                PessoaFisica pessoa = this.PessoaFisicaRepository.Obter(Convert.ToInt32(pessoaViewModel.Codigo));
                PessoaFisica pessoaFisicaAtualizada = Mapper.Map<PessoaFisicaViewModel, PessoaFisica>(pessoaViewModel);

                if (pessoaViewModel.AlterarSenha)
                {
                    String senhaBase64 = Utils.Base64Encode(pessoaViewModel.SenhaAntiga);

                    if (senhaBase64.Equals(pessoa.Senha))
                    {
                        pessoaFisicaAtualizada.Senha = Utils.Base64Encode(pessoaViewModel.NovaSenha);
                    }
                }

                this.PessoaFisicaRepository.Alterar(pessoaFisicaAtualizada);

            }

            return RedirectToAction("Index", "PessoaFisica");
        }
    }
}