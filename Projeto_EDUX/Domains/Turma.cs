﻿using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Domains
{
    public class Turma : BaseDomains
    {
        public int IdTurma { get; set; }
        public string Descricao { get; set; }

        public Guid IdCurso { get; set; }
        [ForeignKey("IdCurso")]
        public Curso Curso{ get; set; }
    }
}
