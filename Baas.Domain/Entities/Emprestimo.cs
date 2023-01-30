using System;

namespace Baas.Domain.Entities
{
    public class Emprestimo
    {
        public string NumeroContrato { get; set; }
        public decimal Valor { get; set; }
        public int NumeroParcelas { get; set; }
        public decimal TaxaJuros { get; set; }
        public DateTime Data { get; set; }

        public void Solicitar(decimal valor, int parcelas, decimal taxaJuros)
        {
            Valor = valor;
            NumeroParcelas = parcelas;
            TaxaJuros = taxaJuros;
        }

        public void PagarParcela(decimal valor)
        {
            Valor -= valor;
        }
    }
}
