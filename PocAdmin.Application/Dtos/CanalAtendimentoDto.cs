using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocAdmin.Application.Dtos
{
    public class CanalAtendimentoDto
    {
        public int CodigoCanal { get; set; }

        public string DescricaoCanal { get; set; } = string.Empty;

        public bool Ativo { get; set; }
    }
}
