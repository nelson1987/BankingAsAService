
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;

public class AlunoTests
{
    [Fact]
    public async Task Buscar_DeveRetornarAlunoEsperado()
    {
        // Arrange
        var alunoEsperado = new Aluno { Id = 1, Nome = "João", DataCriacao = new DateTime(2020, 1, 1) };

        var repositoryMock = new Mock<IAlunoRepository>();
        repositoryMock.Setup(x => x.Buscar(It.IsAny<int>())).Returns(Task.FromResult(alunoEsperado));

        var mediatorMock = new Mock<IMediator>();
        mediatorMock.Setup(x => x.Send(It.IsAny<BuscarAlunoQuery>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(alunoEsperado));

        // Act
        var alunoRetornado = await mediatorMock.Object.Send(new BuscarAlunoQuery(1));

        // Assert
        Assert.Equal(alunoEsperado, alunoRetornado);
        repositoryMock.Verify(x => x.Buscar(1), Times.Once);
    }
}