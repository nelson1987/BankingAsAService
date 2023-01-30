using MediatR;

namespace Baas.Domain.Commands
{
    public class ComprarCartaoCreditoCommand : IRequest<ComprarCartaoCreditoCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
