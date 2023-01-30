using MediatR;

namespace Baas.Domain.Commands
{
    public class AdicionarClienteCommand : IRequest<int>
    {
        public string Nome { get; set; }
    }
}
