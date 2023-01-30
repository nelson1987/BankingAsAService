using MediatR;

namespace Baas.Domain.Commands
{
    public class PagarParcelaEmprestimoCommand : IRequest<PagarParcelaEmprestimoCommandResponse>
    {
        public string NumeroConta { get; set; }
    }
}
