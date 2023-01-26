using System;

namespace Baas.Domain.Account.Create
{
    public class InsertAccountResponse
    {
        public string Number { get; set; }

        public static InsertAccountResponse MappingFromModel(Entities.Account criacaoContaResponse)
        {
            throw new NotImplementedException();
        }
    }
}