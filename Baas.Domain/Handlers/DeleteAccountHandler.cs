using Baas.Domain.Account.Delete;
using Baas.Domain.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Handlers
{
    public class DeleteAccountHandler : IRequestHandler<DeleteAccountCommand, DeleteAccountResponse>
    {
        public Task<DeleteAccountResponse> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}