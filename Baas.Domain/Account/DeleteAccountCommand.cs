using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Account.Create
{
    public class DeleteAccountCommand : IRequest<DeleteAccountResponse>
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
    }
    public class DeleteAccountResponse { }
    public class DeleteAccountHandler : IRequestHandler<DeleteAccountCommand, DeleteAccountResponse>
    {
        public Task<DeleteAccountResponse> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}