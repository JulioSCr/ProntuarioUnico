﻿using ProntuarioUnico.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.ViewModels
{
    public class ProntuarioViewModel
    {
        public List<Prontuario> Prontuarios { get; set; }

        public ProntuarioViewModel(List<Prontuario> prontuarios)
        {
            if (prontuarios != null && prontuarios.Any())
            {
                this.Prontuarios = prontuarios;
            }
            else
            {
                this.Prontuarios = new List<Prontuario>();
            }
        }
    }
}