    public class CaixaEletronicoTests
    {
        [Theory]
        [InlineData(100, new int[] { 1, 2, 5, 10, 20 }, new int[] { 1, 0, 0, 0, 5 })]
        [InlineData(50, new int[] { 1, 2, 5, 10, 20 }, new int[] { 0, 0, 1, 2, 2 })]
        [InlineData(30, new int[] { 1, 2, 5, 10, 20 }, new int[] { 0, 0, 1, 1, 1 })]
        public void Deve_Retornar_Quantidade_De_Notas_Corretas(int valor, int[] notasDisponiveis, int[] resultadoEsperado)
        {
            // Arrange
            var caixaEletronico = new CaixaEletronico(notasDisponiveis);

            // Act
            var resultado = caixaEletronico.Retirar(valor);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void Deve_Lancar_Excecao_Se_Valor_Invalido()
        {
            // Arrange
            var caixaEletronico = new CaixaEletronico(new int[] { 1, 2, 5, 10, 20 });

            // Act & Assert
            Assert.Throws<ArgumentException>(() => caixaEletronico.Retirar(-100));
            Assert.Throws<ArgumentException>(() => caixaEletronico.Retirar(0));
        }
    }
