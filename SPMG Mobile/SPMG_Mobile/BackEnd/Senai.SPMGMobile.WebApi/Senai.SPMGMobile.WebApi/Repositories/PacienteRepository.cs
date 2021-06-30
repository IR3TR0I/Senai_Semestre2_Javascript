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
    public class PacienteRepository : IPacienteRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int id, Paciente NovoPac)
        {
            Paciente PacBuscado = ctx.Pacientes.Find(id);

            if (NovoPac.NomePaciente != null)
            {
                PacBuscado.NomePaciente = NovoPac.NomePaciente;
            }

            if (NovoPac.Telefone != null)
            {
                PacBuscado.Telefone = NovoPac.Telefone;
            }

            ctx.Pacientes.Update(PacBuscado);
            ctx.SaveChanges();
        }

        public Paciente BuscarId(int id)
        {
            return ctx.Pacientes.FirstOrDefault(e => e.IdPaciente == id);
        }

        public void Cadastrar(Paciente NovoPac)
        {
            ctx.Pacientes.Add(NovoPac);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Paciente PacBuscado = ctx.Pacientes.Find(id);
            ctx.Pacientes.Remove(PacBuscado);
            ctx.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes.ToList();
        }

        public List<Paciente> ListarTudo()
        {
            return ctx.Pacientes
                .Include(e => e.Consulta)
                .ToList();
        }
    }

}

