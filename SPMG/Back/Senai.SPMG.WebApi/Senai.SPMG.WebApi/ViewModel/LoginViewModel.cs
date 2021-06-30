using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage= "Coloque um Email de Usuário")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Coloque uma Senha de Usuário")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
