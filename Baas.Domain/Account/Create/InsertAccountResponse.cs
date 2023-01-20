using Baas.Domain.Repositories.Models;
using System;

namespace Baas.Domain.Account.Create
{
    public class InsertAccountResponse
    {
        public string Number { get; set; }

        public static InsertAccountResponse MappingFromModel(AccountModel criacaoContaResponse)
        {
            throw new NotImplementedException();
        }
    }
}