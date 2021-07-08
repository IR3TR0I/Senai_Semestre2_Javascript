using Microsoft.EntityFrameworkCore;
using Senai.SPMGMobile.WebApi.Contexts;
using Senai.SPMGMobile.WebApi.Domains;
using Senai.SPMGMobile.WebApi.Interrfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int id, TiposUsuario tiposUsuarioAtualizado)
        {
            TiposUsuario tipoUsuarioBuscado = ctx.TiposUsuarios.Find(id);

            if (tiposUsuarioAtualizado.TituloTipoUsuario != null)
            {
                tipoUsuarioBuscado.TituloTipoUsuario = tiposUsuarioAtualizado.TituloTipoUsuario;
            }

            ctx.TiposUsuarios.Update(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuarios.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            ctx.TiposUsuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposUsuario tiposUsuarioBuscado = ctx.TiposUsuarios.Find(id);

            ctx.TiposUsuarios.Remove(tiposUsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuarios.ToList();
        }
    }
}

