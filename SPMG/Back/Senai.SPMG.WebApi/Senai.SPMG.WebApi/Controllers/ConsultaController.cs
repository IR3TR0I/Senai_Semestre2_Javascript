using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private IConsultaRepository Consulta { get; set; }

        public ConsultaController()
        {
            ConsultaRepository consultaRepository = new ConsultaRepository();
            
        }

        [Authorize(Roles = "3")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(Consulta.ListarCon());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "3")]
        [HttpGet("ListarTudo")]
        public IActionResult ListarTudo()
        {
            try
            {
                return Ok(Consulta.ListarTudo());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "2")]
        [HttpGet("UsuarioConsultas")]
        public IActionResult UsuarioConsulta()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(Consulta.MinhasCon(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet("MedicoConsultas")]
        public IActionResult MedicoConsultas()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(Consulta.MedicoCon(idUsuario));
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
                return Ok(Consulta.BuscarId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "3")]
        [HttpPost]
        public IActionResult NovoCon(Consulta NovoCon)
        {
            try
            {
                Consulta.Cadastrar(NovoCon);
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
                Consulta.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult AtualizarDados(int id, Consulta NovaCon)
        {
            try
            {
                Consulta.Atualizar(id, NovaCon);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "3")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Consulta status)
        {
            try
            {
                Consulta.Status(id, status.IdSituacao.ToString());
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}    

