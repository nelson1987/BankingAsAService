using MediatR;

namespace Baas.Domain.Commands
{
    public class ResgatarInvestimentoCommand : IRequest<ResgatarInvestimentoCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
