using MediatR;

namespace Baas.Domain.Account.Create
{
    public class AccountQuery : IRequest<AccountQueryResponse>
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
        public int IdEnterpriseAccount { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
    }
}