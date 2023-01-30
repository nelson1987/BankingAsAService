using MediatR;

namespace Baas.Domain.Entities
{
    public class AplicarInvestimentoCommand : IRequest<AplicarInvestimentoCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
