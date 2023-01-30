using MediatR;

namespace Baas.Domain.Entities
{
    public class PagarParcelaEmprestimoCommand : IRequest<PagarParcelaEmprestimoCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
