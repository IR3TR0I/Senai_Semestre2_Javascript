﻿using Senai.SPMGMobile.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi.Interrfaces
{
    public interface IMedicoRepository
    {
        List<Medico> Listar();
        Medico BuscarPorId(int id);
    }
}
