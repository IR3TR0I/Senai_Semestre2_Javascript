using Senai.SPMGMobile.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Interrfaces
{
    interface IConsultaRepository 
    {
        List<Consulta> Listar();


        Consulta BuscarporId(int Id);

        void Cadastrar(Consulta novaConsulta);

        List<Consulta> Minhas(int  IdUsuario);
        void Atualizar(int id, Consulta consultaAtualizada);
        void AlterarStatus(int id, String ConsultaPermissao);
        void Deletar(int id);
        void Descricao(int id, Consulta novaDescricao);
        void AlterarStatus(int id, int? idSituacao);
    }
}
