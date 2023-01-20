using Baas.Domain.Helpers;
using NUnit.Framework;

namespace Baas.Domain.Tests
{
    public class QueryCreatorTests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void SelectAll()
        {
            var nomeTabela = "TB_TRANSACAO";
            var creator = new QueryCreator(nomeTabela);
            string query = creator.GetQuery();
            Assert.AreEqual("SELECT * FROM TB_TRANSACAO", query);
        }
        [Test]
        public void SelectWithColumns()
        {
            var nomeTabela = "TB_TRANSACAO";
            var creator = new QueryCreator(nomeTabela)
                .Colunas("DTA_TRANSACAO", "DTA_AGENDAMENTO");
            string query = creator.GetQuery();
            Assert.AreEqual("SELECT DTA_TRANSACAO, DTA_AGENDAMENTO FROM TB_TRANSACAO", query);
        }
        [Test]
        public void SelectWithPaginationWithoutOrder()
        {
            var nomeTabela = "TB_TRANSACAO";
            var creator = new QueryCreator(nomeTabela)
                .Colunas("DTA_TRANSACAO", "DTA_AGENDAMENTO")
                .Paginacao(1, 3);
            string query = creator.GetQuery();
            Assert.AreEqual("SELECT DTA_TRANSACAO, DTA_AGENDAMENTO FROM TB_TRANSACAO", query);
        }
        [Test]
        public void SelectWithPagination()
        {
            var nomeTabela = "TB_TRANSACAO";
            var creator = new QueryCreator(nomeTabela)
                .Colunas("DTA_TRANSACAO", "DTA_AGENDAMENTO")
                .Paginacao(1, 3)
                .Ordenacao("DTA_TRANSACAO", "DESC");
            string query = creator.GetQuery();
            Assert.AreEqual("SELECT DTA_TRANSACAO, DTA_AGENDAMENTO FROM TB_TRANSACAO ORDER BY DTA_TRANSACAO DESC OFFSET 0 ROWS FETCH NEXT 3 ROWS ONLY", query);
        }
        [Test]
        public void SelectWithFilter()
        {
            var nomeTabela = "TB_TRANSACAO";
            var creator = new QueryCreator(nomeTabela)
                .Search("770", "DOCUMENTO_CONTRAPARTE", "CONTA_CONTRAPARTE");
            string query = creator.GetQuery();
            Assert.AreEqual("SELECT * FROM TB_TRANSACAO WHERE DOCUMENTO_CONTRAPARTE LIKE '%770%' OR CONTA_CONTRAPARTE LIKE '%770%'", query);
        }
    }
}