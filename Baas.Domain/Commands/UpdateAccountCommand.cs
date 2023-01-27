using Baas.Domain.Account.Update;
using MediatR;

namespace Baas.Domain.Commands
{
    public class UpdateAccountCommand : IRequest<UpdateAccountResponse>
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
    }
}