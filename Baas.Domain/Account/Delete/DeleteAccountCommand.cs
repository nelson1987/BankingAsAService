using MediatR;

namespace Baas.Domain.Account.Delete
{
    public class DeleteAccountCommand : IRequest<DeleteAccountResponse>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Tipo { get; set; }
    }
}