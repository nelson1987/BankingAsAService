using MediatR;

namespace Baas.Domain.Entities
{
    public class ComprarCartaoCreditoCommand : IRequest<ComprarCartaoCreditoCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
