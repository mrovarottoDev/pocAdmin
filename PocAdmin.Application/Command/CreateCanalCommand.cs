using MediatR;

namespace Application.Commands.TbCanalAtendimento;

public class CreateCanalCommand : IRequest<int>
{
    public int CodigoCanal { get; set; }
    public string DescricaoCanal { get; set; } = string.Empty;
    public bool Ativo { get; set; }
}