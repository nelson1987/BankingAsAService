using MediatR;

namespace Baas.Domain.Entities
{
    public class ResgatarInvestimentoCommand : IRequest<ResgatarInvestimentoCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
