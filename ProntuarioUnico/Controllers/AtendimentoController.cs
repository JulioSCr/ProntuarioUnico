﻿using AutoMapper;
using ProntuarioUnico.AuxiliaryClasses;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.ViewModels;
using ProntuarioUnico.ViewModels.Atendimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProntuarioUnico.Controllers
{
    public class AtendimentoController : Controller
    {
        private readonly IAtendimentoRepository AtendimentoRepository;
        private readonly ITokenAtendimentoRepository TokenAtendimentoRepository;
        private readonly IPessoaFisicaRepository PessoaFisicaRepository;
        private readonly IMedicoRepository MedicoRepository;
        private readonly IEspecialidadeAtendimentoRepository EspecialidadeAtendimentoRepository;
        private readonly ITipoAtendimentoRepository TipoAtendimentoRepository;


        public AtendimentoController(IAtendimentoRepository atendimentoRepository, ITokenAtendimentoRepository tokenAtendimentoRepository, IPessoaFisicaRepository pessoaFisicaRepository, IMedicoRepository medicoRepository,
                                        IEspecialidadeAtendimentoRepository especialidadeAtendimentoRepository, ITipoAtendimentoRepository tipoAtendimentoRepository)
        {
            this.AtendimentoRepository = atendimentoRepository;
            this.TokenAtendimentoRepository = tokenAtendimentoRepository;
            this.PessoaFisicaRepository = pessoaFisicaRepository;
            this.MedicoRepository = medicoRepository;
            this.EspecialidadeAtendimentoRepository = especialidadeAtendimentoRepository;
            this.TipoAtendimentoRepository = tipoAtendimentoRepository;
        }

        public ActionResult BuscarPaciente(string cpf)
        {
            PessoaFisica pessoa = this.PessoaFisicaRepository.Obter(cpf);
            PessoaFisicaViewModel viewModel = null;

            if (pessoa != default(PessoaFisica))
                viewModel = Mapper.Map<PessoaFisica, PessoaFisicaViewModel>(pessoa);

            ViewBag.HasData = viewModel != default(PessoaFisicaViewModel);
            ViewBag.CPF = cpf;
            return View("Index", viewModel);
        }

        public ActionResult Index(PessoaFisicaViewModel pessoaViewModel)
        {
            ViewBag.HasData = false;
            ViewBag.CPF = "";
            return View(pessoaViewModel);
        }

        public ActionResult Atendimento(int codigoPessoaFisica)
        {
            PessoaFisica pessoaFisica = this.PessoaFisicaRepository.Obter(codigoPessoaFisica);

            ViewBag.TiposAtendimento = this.TipoAtendimentoRepository.ListarAtivos();
            ViewBag.Especialidades = this.EspecialidadeAtendimentoRepository.ListarAtivos();
            ViewBag.CodigoPessoaFisica = codigoPessoaFisica;
            ViewBag.NomePessoa = pessoaFisica.Nome;

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(AtendimentoViewModel viewModel)
        {
            if (viewModel.Valido())
            {
                // Cadastro de Atendimento.
                Atendimento atendimento = Mapper.Map<AtendimentoViewModel, Atendimento>(viewModel);
                atendimento.DataAtendimento = DateTime.Now;
                atendimento.CodigoMedico = Convert.ToInt32(UserAuthentication.ObterCodigoInternoUsuarioLogado());

                atendimento = this.AtendimentoRepository.Cadastrar(atendimento);

                // Geração do Token.
                string codigoToken = Utils.GenerateRandomNumber();
                string codigoTokenBase64 = Utils.Base64Encode(codigoToken);

                TokenAtendimento token = new TokenAtendimento(atendimento.NumeroAtendimento, codigoTokenBase64);

                this.TokenAtendimentoRepository.Cadastrar(token);

                // Envio de Email para paciente com token de verificação

                PessoaFisica pessoa = this.PessoaFisicaRepository.Obter(atendimento.CodigoPessoaFisica);

                if (pessoa == default(PessoaFisica))
                    return Json("Paciente não encontrado");

                Utils.SendEmail(pessoa.Email, $"Olá, {pessoa.Nome}, seu atendimento gerou um token de validação: {codigoToken}", "Atendimento Realizado - Token de Validação");

                ViewBag.CodigoAtendimento = atendimento.NumeroAtendimento;
                ViewBag.NomePessoa = pessoa.Nome;

                return View("FinalizarCadastro");
            }

            return RedirectToAction("Index", "Atendimento");
        }

        public ActionResult FinalizarCadastro()
        {
            return View();
        }

        public ActionResult ValidarToken(TokenViewModel tokenViewModel)
        {
            if (tokenViewModel.Valido())
            {
                // Validação do Token.
                string tokenBase64 = Utils.Base64Encode(tokenViewModel.Token);
                TokenAtendimento token = this.TokenAtendimentoRepository.Obter(tokenBase64, tokenViewModel.NumeroAtendimento.Value);

                if (token == default(TokenAtendimento))
                    return Json("Token inválido.");

                if (!token.Valido())
                    return Json("Token inválido.");

                token.ConfirmarToken();
                token = this.TokenAtendimentoRepository.ConfirmarToken(token.CodigoTokenAtendimento);

                // Envia e-mail para médico informando que a consulta foi autenticada com sucesso

                Atendimento atendimento = this.AtendimentoRepository.Obter(tokenViewModel.NumeroAtendimento.Value);

                if (atendimento == default(Atendimento))
                    return Json("Atendimento não encontrado.");

                Medico medico = this.MedicoRepository.Obter(atendimento.CodigoMedico);

                if (medico == default(Medico))
                    return Json("Médico não encontrado.");

                Utils.SendEmail(medico.Email, $"Olá {medico.NomeGuerra}, o atendimento #{atendimento.NumeroAtendimento} realizado às {atendimento.DataAtendimento.ToString("HH:mm tt")} do dia {atendimento.DataAtendimento.ToString("dd/MM/yyyy")} foi autenticado com sucesso.", "Atendimento autenticado por Token com sucesso!");

                return RedirectToAction("Index", "Atendimento");
            }

            return View();
        }
    }
}