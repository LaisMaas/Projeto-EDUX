﻿using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Domains
{
    public class ObjetivoAluno : BaseDomains
    {
        
        public float Nota { get; set; }
        public DateTime DataAlcancada { get; set; }
        
        public Guid IdAlunoTurma { get; set; }
        [ForeignKey("IdAlunoTurma")]
        public AlunoTurma AlunoTurma{ get; set; }


        public Guid IdObjetivo { get; set; }
        [ForeignKey("IdObjetivo")]
        public Objetivo Objetivo { get; set; }
    }

}