using AutoMapper;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.Mappers
{
    public class PessoaFisicaToPessoaFisicaViewModel : Profile
    {
        public PessoaFisicaToPessoaFisicaViewModel()
        {
            CreateMap<PessoaFisica, PessoaFisicaViewModel>()
                .ForMember(model => model.Codigo, _ => _.MapFrom(viewModel => viewModel.Codigo))
                .ForMember(model => model.Nome, _ => _.MapFrom(viewModel => viewModel.Nome))
                .ForMember(model => model.DataNascimento, _ => _.MapFrom(viewModel => viewModel.DataNascimento))
                .ForMember(model => model.NumeroTelefone, _ => _.MapFrom(viewModel => viewModel.NumeroTelefone))
                .ForMember(model => model.CPF, _ => _.MapFrom(viewModel => viewModel.CPF));
        }

        public override string ProfileName
        {
            get { return "PessoaFisicaToPessoaFisicaViewModel"; }
        }
    }
}