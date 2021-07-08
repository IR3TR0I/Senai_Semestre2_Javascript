using Senai.SPMGMobile.WebApi.Contexts;
using Senai.SPMGMobile.WebApi.Domains;
using Senai.SPMGMobile.WebApi.Interrfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        Situacao ISituacaoRepository.BuscarPorId(int id)
        {
            return ctx.Situacaos.FirstOrDefault(tu => tu.IdSituacao == id);
        }

        List<Situacao> ISituacaoRepository.Listar()
        {
            return ctx.Situacaos.ToList();
        }
    }
}
