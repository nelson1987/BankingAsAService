using System;

namespace Baas.Domain.Repositories.Models
{
    public class TransactionModel
    {
        public int Id{ get; set; }
        public int IdConta { get; set; }
        public DateTime Transacao { get; set; }
        public decimal Valor { get; set; }
    }
}
