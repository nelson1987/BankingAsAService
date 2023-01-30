using System;

namespace Baas.Domain.Entities
{
    public class Investimento
    {
        public string Nome { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Data { get; set; }
        public double TaxaDeRendimento { get; set; }
        public void Aplicar(decimal valor)
        {
            Saldo += valor;
        }

        public void Resgatar(decimal valor)
        {
            Saldo -= valor;
        }

        public double CalcularRendimento()
        {
            return Convert.ToDouble(Saldo) * TaxaDeRendimento;
        }
    }
}
