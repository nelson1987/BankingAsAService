using System;

namespace Baas.Domain.Entities
{
    public class CartaoCredito
    {
        public string NumeroCartao { get; set; }
        public decimal Limite { get; set; }
        public decimal Saldo { get; set; }
        public decimal Pontos { get; set; }

        public void Comprar(decimal valor)
        {
            if (valor > Limite)
                throw new InvalidOperationException();
            Saldo += valor;
        }

        public void PagarFatura(decimal valor)
        {
            Saldo -= valor;
        }

        public void TransferirPontos(CartaoCredito cartaoDestino, decimal pontos)
        {
            Pontos -= pontos;
            cartaoDestino.Pontos += pontos;
        }

        public void AumentarLimite(decimal valor)
        {
            Limite += valor;
        }
    }
}
