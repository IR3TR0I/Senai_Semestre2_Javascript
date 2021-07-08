using Senai.SPMGMobile.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Interrfaces
{
    interface IPacienteRepository
    {
        List<Paciente> Listar();

        Paciente BuscarPorId(int id);

        void Cadastrar(Paciente novoPaciente);

        void Deletar(int id);
    }
}
