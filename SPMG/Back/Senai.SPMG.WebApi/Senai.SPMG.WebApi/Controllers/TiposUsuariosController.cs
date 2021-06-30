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
    public class TiposUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository Tipo { get; set; }

        public TiposUsuariosController()
        {
            Tipo = new TipoUsuarioRepository();
        }

        [Authorize(Roles = "3")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(Tipo.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "3")]
        [HttpGet("Lista")]
        public IActionResult ListarUser()
        {
            try
            {
                return Ok(Tipo.ListarUser());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "3")]
        [HttpPost]
        public IActionResult Cadastrar(TiposUsuario NovoTipo)
        {
            try
            {
                Tipo.Cadastrar(NovoTipo);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "3")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                Tipo.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "3")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TiposUsuario NovoTipo)
        {
            try
            {
                Tipo.Atualizar(id, NovoTipo);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

        

