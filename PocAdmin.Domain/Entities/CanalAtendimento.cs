using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocAdmin.Domain.Entities
{
    public class CanalAtendimento
    {
        public int CodigoCanal { get; set; }

        public string DescricaoCanal { get; set; } = string.Empty;

        public bool Ativo { get; set; }
    }
}
