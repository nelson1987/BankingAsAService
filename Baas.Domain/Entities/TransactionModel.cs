using System;

namespace Baas.Domain.Entities
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public int IdConta { get; set; }
        public DateTime Transacao { get; set; }
        public decimal Valor { get; set; }
        public string BancoContraParte { get; set; }
        public string AgenciaContraParte { get; set; }
        public string ContaContraParte { get; set; }
        public string DocumentoContraParte { get; set; }
    }
}