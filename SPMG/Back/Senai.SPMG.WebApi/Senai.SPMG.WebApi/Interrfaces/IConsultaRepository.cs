using Senai.SPMGMobile.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Interrfaces
{
    interface IConsultaRepository 
    {
        List<Consulta> ListarCon();
        List<Consulta> ListarTudo();
        List<Consulta> MinhasCon(int id);
        List<Consulta> MedicoCon(int id);
        Consulta BuscarId(int id);
        void Cadastrar(Consulta NovoConsulta);
        void Deletar(int id);
        void Atualizar(int id, Consulta NovaConsulta);
        void Status(int id, string status);
    }
}
