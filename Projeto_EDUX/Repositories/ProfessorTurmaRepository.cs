﻿using Projeto_EDUX.Context;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Repositories
{
    public class ProfessorTurmaRepository : IProfessorTurma
    {
        private readonly EduxContext _ctx;

        public ProfessorTurmaRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Adiciona um novo professor
        /// </summary>
        /// <param name="professorTurma">Lista de professores</param>
        /// <returns>Objeto Professor</returns>

        public void Adicionar(ProfessorTurma professorTurma)
        {
            try
            {
                _ctx.ProfessoresTurmas.Add(professorTurma);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public ProfessorTurma BuscarPorId(Guid id)
        {
            ProfessorTurma professorTurma = _ctx.ProfessoresTurmas.Find(id);

            if (professorTurma == null)
                throw new Exception("ProfessorTurma não localizado");
            return professorTurma;
        }



        public void Editar(ProfessorTurma professorTurma)
        {
            ProfessorTurma professorTurma1 = BuscarPorId(professorTurma.Id);

            if (professorTurma.Id == null)
                throw new Exception("ProfessorTurma não localizado");
            _ctx.ProfessoresTurmas.Update(professorTurma1);
            _ctx.SaveChanges();

        }

        public List<ProfessorTurma> Listar()
        {
            try
            {
                List<ProfessorTurma> professorTurmas = _ctx.ProfessoresTurmas.ToList();
                return professorTurmas;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public void Excluir(Guid id)
        {
            ProfessorTurma professorTurma = BuscarPorId(id);
            if (professorTurma == null)
                throw new Exception("Professor não localizado");
            _ctx.ProfessoresTurmas.Remove(professorTurma);
            _ctx.SaveChanges();
        }
    }
}
