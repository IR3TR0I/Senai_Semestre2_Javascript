using Senai.SPMGMobile.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Interrfaces
{
    interface ITipoUsuarioRepository
    {
        List<TiposUsuario> Listar();
        List<TiposUsuario> ListarUser();
        void Cadastrar(TiposUsuario NovoTipo);
        void Deletar(int id);
        void Atualizar(int id, TiposUsuario NovoTipo);
    }
}
