using ProntuarioUnico.AuxiliaryClasses;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.ViewModels;
using ProntuarioUnico.ViewModels.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProntuarioUnico.Controllers
{
    public class ProntuarioController : Controller
    {
        private readonly ITipoAtendimentoRepository TipoAtendimentoRepository;
        private readonly IEspecialidadeAtendimentoRepository EspecialidadeAtendimentoRepository;
        private readonly IProntuarioRepository ProntuarioRepository;
        private readonly IPessoaFisicaRepository PessoaFisicaRepository;
        private readonly IMedicoRepository MedicoRepository;

        public ProntuarioController(IEspecialidadeAtendimentoRepository especialidadeAtendimentoRepository, ITipoAtendimentoRepository tipoAtendimentoRepository, IProntuarioRepository prontuarioRepository,
            IPessoaFisicaRepository pessoaFisicaRepository, IMedicoRepository medicoRepository)
        {
            this.EspecialidadeAtendimentoRepository = especialidadeAtendimentoRepository;
            this.TipoAtendimentoRepository = tipoAtendimentoRepository;
            this.ProntuarioRepository = prontuarioRepository;
            this.PessoaFisicaRepository = pessoaFisicaRepository;
            this.MedicoRepository = medicoRepository;

            CarregarDados();
        }

        // GET: Prontuario
        public ActionResult Index(ProntuarioViewModel model)
        {
            ViewBag.TiposAtendimento = this.TipoAtendimentoRepository.ListarAtivos();
            ViewBag.Especialidades = this.EspecialidadeAtendimentoRepository.ListarAtivos();

            return View(model);
        }

        public ActionResult BuscarAtendimentos(FiltroProntuarioViewModel filtro)
        {
            ViewBag.TiposAtendimento = this.TipoAtendimentoRepository.ListarAtivos();
            ViewBag.Especialidades = this.EspecialidadeAtendimentoRepository.ListarAtivos();

            ViewBag.DataInicial = filtro.DataInicial;
            ViewBag.DataFinal = filtro.DataFinal;
            ViewBag.NumeroAtendimento = filtro.NumeroAtendimento;
            ViewBag.CodigoEspecialidade = filtro.CodigoEspecialidade;
            ViewBag.CodigoTipoAtendimento = filtro.CodigoTipoAtendimento;

            if (filtro.Valido())
            {
                List<Prontuario> prontuarios = this.ProntuarioRepository.Listar(filtro.DataInicial, filtro.DataFinal, filtro.NumeroAtendimento, filtro.CodigoEspecialidade, filtro.CodigoTipoAtendimento);
                ProntuarioViewModel model = new ProntuarioViewModel(prontuarios);

                return View("Index", model);
            }


            return Json("Datas inseridas inválidas.");
        }

        private void CarregarDados()
        {
            string codigo = UserAuthentication.ObterCodigoInternoUsuarioLogado();
            string tipoUsuario = UserAuthentication.ObterTipoUsuario();

            if (tipoUsuario == "pessoa_fisica")
            {
                PessoaFisica pessoa = this.PessoaFisicaRepository.Obter(Convert.ToInt32(codigo));

                ViewBag.TipoUsuario = tipoUsuario;
                ViewBag.NomeUsuario = pessoa.Nome;
                ViewBag.NomePagina = $"Consulta de Prontuário - {pessoa.Nome}";
            }
            else
            {
                Medico medico = this.MedicoRepository.Obter(Convert.ToInt32(codigo));

                ViewBag.TipoUsuario = tipoUsuario;
                ViewBag.NomeUsuario = medico.NomeGuerra;
            }
        }
    }
}