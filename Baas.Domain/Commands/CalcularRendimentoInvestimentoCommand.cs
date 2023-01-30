using MediatR;

namespace Baas.Domain.Entities
{
    public class CalcularRendimentoInvestimentoCommand : IRequest<CalcularRendimentoInvestimentoCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
