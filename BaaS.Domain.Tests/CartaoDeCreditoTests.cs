using Baas.Domain.Entities;
using System;
using Xunit;

namespace BaaS.Domain.Tests
{
    public class CartaoDeCreditoTests
    {
        private CartaoCredito _cartao;

        [Fact]
        public void PagarFatura_ZeraSaldoDevedor()
        {
            // Arrange
            _cartao = new CartaoCredito();
            _cartao.Limite = 1000;
            _cartao.Comprar(500);

            // Act
            _cartao.PagarFatura(500);

            // Assert
            Assert.Equal(0, _cartao.Saldo);
        }

        [Fact]
        public void Comprar_AdicionaValorAoSaldoDevedor()
        {
            // Arrange
            _cartao = new CartaoCredito();
            _cartao.Limite = 1000;

            // Act
            _cartao.Comprar(500);

            // Assert
            Assert.Equal(500, _cartao.Saldo);
        }

        [Fact]
        public void Comprar_SaldoDevedorNaoPodeSerSuperiorAoLimite()
        {
            // Arrange
            _cartao = new CartaoCredito();
            _cartao.Limite = 1000;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _cartao.Comprar(1100));
        }

        [Fact]
        public void PagarFatura_QuandoValorValido_DeveReduzirSaldo()
        {
            // Arrange
            var cartao = new CartaoCredito
            {
                Saldo = 100
            };

            // Act
            cartao.PagarFatura(50);

            // Assert
            Assert.Equal(50, cartao.Saldo);
        }

        [Fact]
        public void AumentarLimite_QuandoValorValido_DeveriaAumentarLimite()
        {
            // Arrange
            var cartao = new CartaoCredito
            {
                Limite = 1000
            };

            // Act
            cartao.AumentarLimite(500);

            // Assert
            Assert.Equal(1500, cartao.Limite);
        }
    }
}