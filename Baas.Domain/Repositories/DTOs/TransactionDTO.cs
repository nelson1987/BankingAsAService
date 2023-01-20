using Baas.Domain.Transaction;

namespace Baas.Domain.Repositories.DTOs
{
    public class TransactionDTO
    {
        public int Conta { get; set; }
        public static TransactionDTO MappingFromModel(GetTransactionQuery request)
        {
            return new TransactionDTO()
            {
                Conta = 1
            };
        }
    }
}