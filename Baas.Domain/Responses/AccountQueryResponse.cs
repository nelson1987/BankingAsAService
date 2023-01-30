namespace Baas.Domain.Responses
{
    public class AccountQueryResponse
    {
        public string Number { get; set; }

        public static AccountQueryResponse MappingFromModel(Entities.Account criacaoContaResponse)
        {
            return new AccountQueryResponse()
            {
                Number = criacaoContaResponse.Numero
            };
        }
    }
}