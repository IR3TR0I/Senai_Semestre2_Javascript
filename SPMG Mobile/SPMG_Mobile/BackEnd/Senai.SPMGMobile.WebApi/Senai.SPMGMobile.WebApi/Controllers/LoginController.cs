using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.SPMGMobile.WebApi.Domains;
using Senai.SPMGMobile.WebApi.Interrfaces;
using Senai.SPMGMobile.WebApi.Repositories;
using Senai.SPMGMobile.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Seu E-mail ou senha estão Inválidos!");
                }


                var Claims = new[]
                {
                    // e-mail do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    // ID do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    // tipo de usuário que foi autenticado (Administrador ou Comum)
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),

                    //  tipo de usuário que foi autenticado (Administrador ou Comum) de forma personalizada
                    new Claim("role", usuarioBuscado.IdTipoUsuario.ToString()),

                    // nome do usuário que foi autenticado
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome)
                };
                //token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmg-Chave-autenticação"));
                //header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //gerando o Token
                var Token = new JwtSecurityToken(
                    //Emissor
                    issuer: "Spmed.webApi",
                    //destino do Token
                    audience: "Spmed.webApi",
                    //todos os dados que foram definidos nas claims
                    claims: Claims,
                    //Tempo para o token Expirar
                    expires: DateTime.Now.AddMinutes(30),
                    //credencias do Token 
                    signingCredentials: creds
                );

                //Retonar OK Junto ao token
                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(Token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}


