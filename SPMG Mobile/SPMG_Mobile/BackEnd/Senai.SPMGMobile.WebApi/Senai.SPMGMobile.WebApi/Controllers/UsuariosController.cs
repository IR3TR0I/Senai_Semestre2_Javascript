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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        private UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_usuarioRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            try
            {
                // Retorna a resposta da requisição e chama o método
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception ErrorMessage)
            {

                return BadRequest(ErrorMessage);
            }
        }

        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {
                // Faz a chamada para o método
                _usuarioRepository.Cadastrar(novoUsuario);
                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            try
            {
                // Faz a chamada para o método
                _usuarioRepository.Atualizar(id, usuarioAtualizado);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Chamando o método
                _usuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}

