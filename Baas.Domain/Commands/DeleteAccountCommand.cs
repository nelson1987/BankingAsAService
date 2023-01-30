using Baas.Domain.Responses;
using MediatR;

namespace Baas.Domain.Commands
{
    public class DeleteAccountCommand : IRequest<DeleteAccountResponse>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Tipo { get; set; }
    }
}