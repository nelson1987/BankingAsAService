using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Account.Create
{
    public class CreateAccountCommand : IRequest<CreateAccountResponse>
    {
        public int Id { get; set; }
    }

    public class CreateAccountResponse
    {
    }

    public class CreateAccountModel
    {
    }

    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
    {
        public async Task<CreateAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}