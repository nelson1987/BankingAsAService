using System;

namespace Baas.Domain.Repositories.Models
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
    public class CounterPartieModel
    {
        public string BancoContraParte { get; set; }
        public string AgenciaContraParte { get; set; }
        public string ContaContraParte { get; set; }
        public string DocumentoContraParte { get; set; }
    }
}

//[IDT_TRANSACTION]
//,[IDT_CONTA]
//,[DTA_TRANSACAO]
//,[VLR_TRANSACAO]
//,[DTA_AGENDAMENTO]

//,[BANCO_CONTRAPARTE]
//,[AGENCIA_CONTRAPARTE]
//,[CONTA_CONTRAPARTE]
//,[DOCUMENTO_CONTRAPARTE] 