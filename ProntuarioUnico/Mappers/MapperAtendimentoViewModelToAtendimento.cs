using AutoMapper;
using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.Mappers
{
    public class MapperAtendimentoViewModelToAtendimento : Profile
    {
        public MapperAtendimentoViewModelToAtendimento()
        {
            CreateMap<AtendimentoViewModel, Atendimento>()
                .ForMember(model => model.CrmMedico, _ => _.MapFrom(viewModel => viewModel.CodigoMedico))
                .ForMember(model => model.CodigoEspecialidade, _ => _.MapFrom(viewModel => viewModel.IdEspecialidade))
                .ForMember(model => model.DescricaoObservacao, _ => _.MapFrom(viewModel => viewModel.Observacao));
        }

        public override string ProfileName
        {
            get { return "MapperAtendimentoViewModelToAtendimento"; }
        }
    }
}