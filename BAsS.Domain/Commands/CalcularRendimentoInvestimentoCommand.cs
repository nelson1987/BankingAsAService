using MediatR;

namespace Baas.Domain.Commands
{
    public class CalcularRendimentoInvestimentoCommand : IRequest<CalcularRendimentoInvestimentoCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
