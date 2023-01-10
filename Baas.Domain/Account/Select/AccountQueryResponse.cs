using Baas.Domain.Repositories.Models;

namespace Baas.Domain.Account.Create
{
    public class AccountQueryResponse
    {
        public string Number { get; set; }

        public static AccountQueryResponse MappingFromModel(AccountModel criacaoContaResponse)
        {
            return new AccountQueryResponse()
            {
                Number = criacaoContaResponse.Numero
            };
        }
    }
}