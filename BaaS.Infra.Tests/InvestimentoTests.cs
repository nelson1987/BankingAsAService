using Baas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BaaS.Infra.Tests
{
    public class InvestimentoTests
    {
        [Fact]
        public async Task CriarInvestimento_DeveSalvarInvestimentoNoBanco()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BancoContext>()
                .UseInMemoryDatabase(databaseName: "CriarInvestimento_DeveSalvarInvestimentoNoBanco")
                .Options;

            var valor = 100.0;
            var id = 1;

            var command = new CriarInvestimentoCommand { Id = id, Valor = valor };

            // Act
            using (var context = new BancoContext(options))
            {
                var handler = new InvestimentoCommandHandler(context);
                var result = await handler.Handle(command, CancellationToken.None);

                // Assert
                Assert.True(result);
            }

            using (var context = new BancoContext(options))
            {
                var investimento = await context.Investimentos.FindAsync(id);
                Assert.Equal(valor, investimento.Valor);
            }
        }

        [Fact]
        public async Task ObterInvestimento_DeveRetornarInvestimento()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BancoContext>()
                .UseInMemoryDatabase(databaseName: "ObterInvestimento_DeveRetornarInvestimento")
                .Options;

            var valor = 100.0;
            var id = 1;

            using (var context = new BancoContext(options))
            {
                var investimento = new Investimento { Id = id, Valor = valor };
                context.Investimentos.Add(investimento);
                context.SaveChanges();
            }

            var query = new ObterInvestimentoQuery { Id = id };

            // Act
            using (var context = new BancoContext(options))
            {
                var handler = new InvestimentoQueryHandler(context);
                var result = await handler.Handle(query, CancellationToken.None);

                // Assert
                Assert.Equal(valor, result.Valor);
            }
        }
    }
}