using MediatR;

namespace Baas.Domain.Entities
{
    public class ObterClienteQuery : IRequest<Cliente>
    {
        public int Id { get; set; }
    }

}
