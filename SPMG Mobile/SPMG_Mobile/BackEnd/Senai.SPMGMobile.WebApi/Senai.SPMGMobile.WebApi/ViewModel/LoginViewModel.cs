using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.ViewModel
{
    public class LoginViewModel
    {
        //Required Define que a propriedade é obrigatória
        [Required(ErrorMessage= "Coloque um Email de Usuário")]
        public string Email { get; set; }
        //Required Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Coloque uma Senha de Usuário")]
        public string Senha { get; set; }
    }
}
