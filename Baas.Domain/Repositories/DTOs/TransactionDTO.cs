using Baas.Domain.Transaction;

namespace Baas.Domain.Repositories.DTOs
{
    public class TransactionDTO
    {
        public string[] Colunas => new[] { "DTA_TRANSACAO", "VLR_TRANSACAO" };
        public string SortingBy => "DTA_TRANSACAO";
        public string SortingType => "DESC";
        public string SearchFilter => "895";

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