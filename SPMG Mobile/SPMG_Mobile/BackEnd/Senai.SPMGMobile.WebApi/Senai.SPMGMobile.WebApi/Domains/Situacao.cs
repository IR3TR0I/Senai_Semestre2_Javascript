using System;
using System.Collections.Generic;

#nullable disable

namespace Senai.SPMGMobile.WebApi.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdSituacao { get; set; }
        public string DescricaoSituacao { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
