using MediatR;

namespace Baas.Domain.Entities
{
    public class PagarFaturaCartaoCreditoCommand : IRequest<PagarFaturaCartaoCreditoCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
