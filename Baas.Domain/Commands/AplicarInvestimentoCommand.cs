using MediatR;

namespace Baas.Domain.Commands
{
    public class AplicarInvestimentoCommand : IRequest<AplicarInvestimentoCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
