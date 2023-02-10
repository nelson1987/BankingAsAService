using Baas.Domain.Responses;
using MediatR;
using System.Collections.Generic;

namespace Baas.Domain.Account.Create
{
    public class AccountQuery : IRequest<IList<AccountQueryResponse>>
    {
        //public int Id { get; set; }
        public string? Numero { get; set; }
        public string? Tipo { get; set; }
        public int? IdCliente { get; set; }
        //public int IdEmpresa { get; set; }
        //public int IdEnterpriseAccount { get; set; }
        //public string Name { get; set; }
        //public string Document { get; set; }
    }
}