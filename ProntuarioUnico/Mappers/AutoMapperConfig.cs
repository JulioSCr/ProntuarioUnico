﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MapperAtendimentoViewModelToAtendimento>();
                x.AddProfile<PessoaFisicaToPessoaFisicaViewModel>();
                x.AddProfile<PessoaFisicaViewModelToPessoaFisica>();
            });
        }
    }
}