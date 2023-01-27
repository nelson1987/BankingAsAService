using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Account.Delete
{
    public class DeleteAccountHandler : IRequestHandler<DeleteAccountCommand, DeleteAccountResponse>
    {
        public Task<DeleteAccountResponse> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}