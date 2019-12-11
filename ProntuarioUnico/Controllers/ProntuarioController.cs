using AutoMapper;
using Microsoft.Reporting.WebForms;
using ProntuarioUnico.AuxiliaryClasses;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.Filters;
using ProntuarioUnico.ViewModels;
using ProntuarioUnico.ViewModels.Filtros;
using ProntuarioUnico.ViewModels.Relatorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProntuarioUnico.Controllers
{
    [AutorizacaoFilter]
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

            ViewBag.NomePagina = $"Consulta de Prontuário - {UserAuthentication.ObterNome()}";
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

        public ActionResult ImprimirPDF(FiltroProntuarioViewModel filtro)
        {
            if (filtro.Valido())
            {
                List<Prontuario> prontuarios = this.ProntuarioRepository.Listar(filtro.DataInicial, filtro.DataFinal, filtro.NumeroAtendimento, filtro.CodigoEspecialidade, filtro.CodigoTipoAtendimento);
                List<AtendimentoPDFView> atendimentos = Mapper.Map<List<Prontuario>, List<AtendimentoPDFView>>(prontuarios);

                LocalReport relatorio = new LocalReport();
                relatorio.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\Reports\ReportProntuario.rdlc";
                relatorio.DataSources.Add(new ReportDataSource("Prontuario", atendimentos));

                //parametros
                relatorio.SetParameters(new ReportParameter("DataImpressao", DateTime.Now.ToString("dd/MM/yyyy")));
                relatorio.SetParameters(new ReportParameter("Nome", UserAuthentication.ObterNome()));
                relatorio.SetParameters(new ReportParameter("Periodo", $"{filtro.DataInicial.ToString("dd/MM/yyyy")} a {filtro.DataFinal.ToString("dd/MM/yyyy")}"));

                string descricao = "Todos";

                if (filtro.CodigoTipoAtendimento.HasValue)
                {
                    TipoAtendimento tipo = this.TipoAtendimentoRepository.Obter(filtro.CodigoTipoAtendimento.Value);

                    if (tipo == default(TipoAtendimento))
                    {
                        descricao = tipo.DescricaoTipoAtendimento;
                    }
                }

                relatorio.SetParameters(new ReportParameter("Atendimento", descricao));
                descricao = "Todos";

                if (filtro.CodigoTipoAtendimento.HasValue)
                {
                    EspecialidadeAtendimento especialidade = this.EspecialidadeAtendimentoRepository.Obter(filtro.CodigoTipoAtendimento.Value);

                    if (especialidade == default(EspecialidadeAtendimento))
                    {
                        descricao = especialidade.DescricaoEspecialidade;
                    }
                }

                relatorio.SetParameters(new ReportParameter("Especialidade", descricao));

                return GerarArquivoPDF(relatorio);
            }

            return View("BuscarAtendimentos", filtro);
        }

        private FileContentResult GerarArquivoPDF(LocalReport relatorio)
        {
            String reportType = "PDF";
            String mimeType;
            String encoding;
            String fileNameExtension;
            String deviceInfo;
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            deviceInfo = "<DeviceInfo>" + "  <OutputFormat>" + reportType + "</OutputFormat>" + "</DeviceInfo>";

            renderedBytes = relatorio.Render(
            reportType,
            deviceInfo,
            out mimeType,
            out encoding,
            out fileNameExtension,
            out streams,
            out warnings);

            return File(renderedBytes, mimeType);
        }
    }
}