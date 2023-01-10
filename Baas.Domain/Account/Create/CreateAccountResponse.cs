using Baas.Domain.Repositories.Models;
using System;

namespace Baas.Domain.Account.Create
{
    public class CreateAccountResponse
    {
        public string Number { get; set; }

        public static CreateAccountResponse MappingFromModel(AccountModel criacaoContaResponse)
        {
            throw new NotImplementedException();
        }
    }
}