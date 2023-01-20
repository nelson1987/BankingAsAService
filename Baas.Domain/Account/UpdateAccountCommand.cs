using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Baas.Domain.Account.Create
{
    public class UpdateAccountCommand : IRequest<UpdateAccountResponse>
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
    }
    public class UpdateAccountResponse { }
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, UpdateAccountResponse>
    {
        public Task<UpdateAccountResponse> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}