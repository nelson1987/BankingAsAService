using MediatR;

namespace Baas.Domain.Commands
{
    public class PagarFaturaCartaoCreditoCommand : IRequest<PagarFaturaCartaoCreditoCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
