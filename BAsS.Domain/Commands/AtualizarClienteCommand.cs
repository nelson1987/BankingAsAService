using MediatR;

namespace Baas.Domain.Commands
{
    public class AtualizarClienteCommand : IRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
