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

        public void Atualizar(int id, TiposUsuario NovoTipo)
        {
            TiposUsuario TipoBuscado = ctx.TiposUsuarios.Find(id);

            if (NovoTipo.TituloTipoUsuario != null)
            {
                TipoBuscado.TituloTipoUsuario = NovoTipo.TituloTipoUsuario;
            }

            ctx.TiposUsuarios.Update(TipoBuscado);
            ctx.SaveChanges();
        }

        public void Cadastrar(TiposUsuario NovoTipo)
        {
            ctx.TiposUsuarios.Add(NovoTipo);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposUsuario TipoBuscado = ctx.TiposUsuarios.Find(id);
            ctx.TiposUsuarios.Remove(TipoBuscado);
            ctx.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuarios.ToList();
        }

        public List<TiposUsuario> ListarUser()
        {
            return ctx.TiposUsuarios.
                Include(e => e.Usuarios).ToList();
        }
    }
}

