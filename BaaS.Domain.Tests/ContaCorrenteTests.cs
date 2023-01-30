using Baas.Domain.Entities;
using Xunit;

namespace BaaS.Domain.Tests
{
    public class ContaCorrenteTests
    {
        private ContaCorrente _conta;

        [Fact]
        public void Depositar_AdicionaValorAoSaldo()
        {
            // Arrange
            _conta = new ContaCorrente();

            // Act
            _conta.Depositar(100);

            // Assert
            Assert.Equal(100, _conta.Saldo);
        }

        [Fact]
        public void Sacar_SubtraiValorDoSaldo()
        {
            // Arrange
            _conta = new ContaCorrente();
            _conta.Depositar(100);

            // Act
            _conta.Sacar(50);

            // Assert
            Assert.Equal(50, _conta.Saldo);
        }

        [Fact]
        public void Transferir_TransfereValorEntreContas()
        {
            // Arrange
            _conta = new ContaCorrente();
            var contaDestino = new ContaCorrente();
            _conta.Depositar(100);

            // Act
            _conta.Transferir(contaDestino, 50);

            // Assert
            Assert.Equal(50, _conta.Saldo);
            Assert.Equal(50, contaDestino.Saldo);
        }
    }
}
