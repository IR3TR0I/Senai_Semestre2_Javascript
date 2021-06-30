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
        private new IUsuarioRepository User { get; set; }

        public UsuariosController()
        {
            User = new UsuarioRepository();
        }
        [Authorize(Roles = "3")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(User.Lista());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "3")]
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                return Ok(User.BuscarId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario NovoUser)
        {
            try
            {
                User.Cadastro(NovoUser);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                User.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario NovoUser)
        {
            try
            {
                User.Atualizar(id, NovoUser);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

