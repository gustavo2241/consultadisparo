﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaDisparos.Models
{
    public class DisparosErroSemAssociacaoFlgDisparadoZeroModel
    {
        private DisparosErroSemAssociacaoFlgDisparadoZeroContext context;

        public string idDisparo { get; set; }
        public string flgDisparado { get; set; }
        public string flgEnfileirado { get; set; }
        public string txtNome { get; set; }
        public string dataAgendamento { get; set; }
        public string dataExpiracao { get; set; }
        public string nomeBase { get; set; }

    }
}
