using MediatR;

namespace Baas.Domain.Account.Update
{
    public class UpdateAccountCommand : IRequest<UpdateAccountResponse>
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
    }
}