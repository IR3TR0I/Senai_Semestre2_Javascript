using Senai.SPMGMobile.WebApi.Contexts;
using Senai.SPMGMobile.WebApi.Domains;
using Senai.SPMGMobile.WebApi.Interrfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int id, Usuario NovoUser)
        {
            Usuario UserBuscado = ctx.Usuarios.Find(id);

            if (NovoUser.Email != null)
            {
                UserBuscado.Email = NovoUser.Email;
            }
            ctx.Usuarios.Update(UserBuscado);
            ctx.SaveChanges();
        }

        public Usuario BuscarId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastro(Usuario NovoUser)
        {
            ctx.Add(NovoUser);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario UserBuscado = ctx.Usuarios.Find(id);
            ctx.Usuarios.Remove(UserBuscado);
            ctx.SaveChanges();
        }

        public List<Usuario> Lista()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }

    }
}

