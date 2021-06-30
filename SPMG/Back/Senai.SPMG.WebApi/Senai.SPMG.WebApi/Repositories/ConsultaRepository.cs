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
    public class ConsultaRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int id, Consulta NovaConsulta)
        {
            Consulta ConBuscada = ctx.Consultas.Find(id);

            if (NovaConsulta.Descricao != null)
            {
                ConBuscada.Descricao = NovaConsulta.Descricao;
            }

            ctx.Consultas.Update(ConBuscada);
            ctx.SaveChanges();
        }

        public Consulta BuscarId(int id)
        {
            return ctx.Consultas.FirstOrDefault(e => e.IdConsulta == id);
        }

        public void Cadastrar(Consulta NovoConsulta)
        {
            ctx.Consultas.Add(NovoConsulta);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Consulta ConBuscada = ctx.Consultas.Find(id);
            ctx.Consultas.Remove(ConBuscada);
            ctx.SaveChanges();
        }


        public List<Consulta> ListarCon()
        {
            return ctx.Consultas.ToList();
        }

        public List<Consulta> ListarTudo()
        {
            return ctx.Consultas
                .Include(e => e.IdPacienteNavigation)
                .Include(e => e.IdMedicoNavigation)
                .Include(e => e.IdSituacaoNavigation)
                .ToList();
        }

        public List<Consulta> MedicoCon(int id)
        {
            Medico MedBuscado = ctx.Medicos.FirstOrDefault(e => e.IdUsuario == id);

            return ctx.Consultas
               .Include(e => e.IdPacienteNavigation)
               .Include(e => e.IdSituacaoNavigation)
               .Where(e => e.IdMedico == MedBuscado.IdMedico)
               .ToList();
        }

        public List<Consulta> MinhasCon(int id)
        {
            Paciente PacBuscado = ctx.Pacientes.FirstOrDefault(e => e.IdUsuario == id);

            return ctx.Consultas
                .Include(e => e.IdMedicoNavigation)
                .Include(e => e.IdMedicoNavigation.IdClinicaNavigation)
                .Include(e => e.IdMedicoNavigation.IdEspecialidadeNavigation)
                .Include(e => e.IdSituacaoNavigation)
                .Where(e => e.IdPaciente == PacBuscado.IdPaciente)
                .ToList();
        }

        public void Status(int id, string status)
        {
            Consulta consulta = ctx.Consultas
                .FirstOrDefault(e => e.IdConsulta == id);

            switch (status)
            {
                case "1":
                    consulta.IdSituacao = 1;
                    break;

                case "2":
                    consulta.IdSituacao = 2;
                    break;

                case "3":
                    consulta.IdSituacao = 3;
                    break;

                default:
                    consulta.IdSituacao = consulta.IdSituacao;
                    break;
            }

            ctx.Consultas.Update(consulta);
            ctx.SaveChanges();
        }
    }
}
