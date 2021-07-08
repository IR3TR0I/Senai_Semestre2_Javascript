using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SPMGMobile.WebApi.Domains;
using Senai.SPMGMobile.WebApi.Interrfaces;
using Senai.SPMGMobile.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "1")]
    public class TiposUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tiposUsuarioRepository { get; set; }

        public TiposUsuariosController()
        {
            _tiposUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Retorna a requisição e chama o método
                return Ok(_tiposUsuarioRepository.Listar());
            }
            catch (Exception Erro)
            {

                return BadRequest(Erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //Retorna a requisição e chama o método
                return Ok(_tiposUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception Erro)
            {

                return BadRequest(Erro);
            }
        }

        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipoUsuario)
        {
            try
            {
                //Retorna a requisição e chama o método
                _tiposUsuarioRepository.Cadastrar(novoTipoUsuario);

                //retornar Status Code 201
                return StatusCode(201);
            }
            catch (Exception Ex)
            {

                return BadRequest(Ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tipoUsuarioAtualizado)
        {
            try
            {
                //Retorna a requisição e chama o método
                _tiposUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);
                //retornar status code 204
                return StatusCode(204);
            }
            catch (Exception Erro)
            {

                return BadRequest(Erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Retorna a requisição e chama o método de deletar por Id
                _tiposUsuarioRepository.Deletar(id);

                //retornar um 204
                return StatusCode(204);
            }
            catch (Exception Erro)
            {

                return BadRequest(Erro);
            }
        }
    }
}

        

