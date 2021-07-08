using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Senai.SPMGMobile.WebApi.Domains;
using Senai.SPMGMobile.WebApi.Interrfaces;
using Senai.SPMGMobile.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
       private IConsultaRepository _consultaRepository { get; set; }

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consultaRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_consultaRepository.BuscarporId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);

                return StatusCode(201);
                 
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Consulta ConsultaAtualizada)
        {
            try
            {
                _consultaRepository.Atualizar(id, ConsultaAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _consultaRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        //listar minhas Consultas
        [HttpGet("Minhas")]
        public IActionResult GetMy()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.Minhas(IdUsuario));
            }
            catch (Exception erro)
            {

                return BadRequest(new 
                { 
                    mensagem = "Não podemos mostrar suas consultas se o usuário não estiver logado!",
                    erro
                });
            }
        }

        [Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Consulta ConsultaAtualizada)
        {
            try
            {
                _consultaRepository.AlterarStatus(id, ConsultaAtualizada.IdSituacao);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(new 
                { 
                    mensagem = "apenas o ADM pode alterar a situação da consulta",
                    erro
                });
            }
        }

        [Authorize(Roles = "2")]
        [HttpPatch("descricao/{id}")]
        public IActionResult Descricao(int id, Consulta novaDescricao)
        {
            try
            {
                _consultaRepository.Descricao(id, novaDescricao);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

              return BadRequest(new 
              { 
                mensagem = "Apenas o médico pode alterar a descrição!",
                erro
              });
            }    
        }
    }   
}    

