using Baas.Domain.Account.Create;
using System;

namespace Baas.Domain.Repositories.DTOs
{
    public class TransactionDTO
    {
        public static TransactionDTO MappingFromModel(CreateAccountCommand request)
        {
            return new TransactionDTO();
        }

    }
}
