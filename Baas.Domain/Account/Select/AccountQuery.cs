using MediatR;

namespace Baas.Domain.Account.Create
{
    public class AccountQuery : IRequest<AccountQueryResponse>
    {
        public string Numero { get; set; }
        public string IdCliente { get; set; }
        public string IdEmpresa { get; set; }
    }
}