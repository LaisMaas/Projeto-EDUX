﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Interfaces;
using Projeto_EDUX.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetivoController : ControllerBase
    {
        private readonly IObjetivocs _objetivoRepository;

        public ObjetivoController()
        {
            _objetivoRepository = new ObjetivoRepository();
        }

        // GET api/<ObjetivoController>
        /// <summary>
        /// Ler todos os Objetivos cadastrados
        /// </summary>
        /// <returns>Lista de objetivos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var descricao = _objetivoRepository.Listar();

                if (descricao.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = descricao.Count,
                    data = descricao
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Envie um email para email@email.com informando que ocorreu um erro no endpoint Get/produtos"
                });
            }
        }



        // GET api/<ObjetivoController>/5
        /// <summary>
        /// Busca um unico objetivo no sistema pelo seu ID
        /// </summary>
        /// <param name="id">ID do objetivo</param>
        /// <returns>Categoria procurado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Objetivo objetivo = _objetivoRepository.BuscarPorId(id);

                if (objetivo == null)
                    return NotFound();

                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }






        }


        // POST api/<ObjetivoController>
        /// <summary>
        /// Cadastra um Objetivo no sistema
        /// </summary>
        /// <param name="objetivo">objetivo</param>
        /// <returns>objetivo cadastrado</returns>
        [HttpPost]
        public IActionResult Post(Objetivo objetivo)
        {
            try
            {
                _objetivoRepository.Adicionar(objetivo);

                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ObjetivoController>/5
        /// <summary>
        /// Exclui um objetivodo sistema
        /// </summary>
        /// <param name="id">ID do objetivo a ser excluida</param>
        /// <returns>ID do objetivo excluido</returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var objetivo = _objetivoRepository.BuscarPorId(id);
                if (objetivo == null)
                    return NotFound();

                _objetivoRepository.Remover(id);

                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }








    }
}
