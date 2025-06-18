using PocAdmin.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocAdmin.Application.Validators
{
    public class CanalAtendimentoValidator : AbstractValidator<CanalAtendimentoDto>
    {
        public CanalAtendimentoValidator()
        {
            RuleFor(x => x.CodigoCanal)
                .GreaterThan(0);

            RuleFor(x => x.DescricaoCanal)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
