using Senai.SPMGMobile.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Interrfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);

        List<Usuario> Lista();
        Usuario BuscarId(int id);
        void Cadastro(Usuario NovoUser);
        void Deletar(int id);
        void Atualizar(int id, Usuario NovoUser);
    }
}
