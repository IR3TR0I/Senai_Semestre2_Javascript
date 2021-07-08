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
    public class MedicoRepository : IMedicoRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();
        public Medico BuscarPorId(int id)
        {
            return ctx.Medicos.FirstOrDefault(tu => tu.IdMedico == id);
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos

            .Include(p => p.IdUsuarioNavigation)

            .ToList();
        }

    }
}
