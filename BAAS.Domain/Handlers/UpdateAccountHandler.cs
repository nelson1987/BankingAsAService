using Baas.Domain.Commands;
using Baas.Domain.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Handlers
{
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, UpdateAccountResponse>
    {
        public Task<UpdateAccountResponse> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}