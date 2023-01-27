using Baas.Domain.Entities;
using System;

namespace Baas.Domain.Transaction
{
    public class GetTransactionQueryResponse
    {
        public int Id { get; set; }
        public int IdConta { get; set; }
        public DateTime Transacao { get; set; }
        public decimal Valor { get; set; }
        public string BancoContraParte { get; set; }
        public string AgenciaContraParte { get; set; }
        public string ContaContraParte { get; set; }
        public string DocumentoContraParte { get; set; }

        public static GetTransactionQueryResponse MappingFromModel(TransactionModel model)
        {
            return new GetTransactionQueryResponse()
            {
                Id = model.Id,
                IdConta = model.IdConta,
                Transacao = model.Transacao,
                Valor = model.Valor,
                AgenciaContraParte = model.AgenciaContraParte,
                BancoContraParte = model.BancoContraParte,
                ContaContraParte = model.ContaContraParte,
                DocumentoContraParte = model.DocumentoContraParte
            };
        }
    }
}