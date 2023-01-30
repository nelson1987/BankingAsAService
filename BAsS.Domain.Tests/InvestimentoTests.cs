using Baas.Domain.Entities;
using Xunit;

namespace BaaS.Domain.Tests
{
    public class InvestimentoTests
    {
        private Investimento _investimento;

        [Fact]
        public void Depositar_AdicionaValorAoSaldo()
        {
            // Arrange
            _investimento = new Investimento();

            // Act
            _investimento.Aplicar(100);

            // Assert
            Assert.Equal(100, _investimento.Saldo);
        }

        [Fact]
        public void Resgatar_SubtraiValorDoSaldo()
        {
            // Arrange
            _investimento = new Investimento();
            _investimento.Aplicar(100);

            // Act
            _investimento.Resgatar(50);

            // Assert
            Assert.Equal(50, _investimento.Saldo);
        }

        [Fact]
        public void CalcularRendimento_RetornaRendimentoEsperado()
        {
            // Arrange
            _investimento = new Investimento();
            _investimento.Aplicar(1000);
            _investimento.TaxaDeRendimento = 0.05;

            // Act
            var rendimento = _investimento.CalcularRendimento();

            // Assert
            Assert.Equal(50, rendimento);
        }
    }
}
