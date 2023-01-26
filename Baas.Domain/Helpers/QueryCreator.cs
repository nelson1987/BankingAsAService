using System.Text;

namespace Baas.Domain.Helpers
{
    public class QueryCreator
    {
        private readonly string nomeTabela;
        private string colunas;
        private string filtro;
        private string paginacao;
        private string ordenacao;
        private bool ordenacaoExecutada;
        private string query
        {
            get
            {
                StringBuilder query = new StringBuilder();
                query.Append($"SELECT {GetColuna()} ");
                query.Append($"FROM {nomeTabela} ");
                if (string.IsNullOrEmpty(filtro) is false)
                    query.Append($"WHERE {filtro} ");
                if (string.IsNullOrEmpty(ordenacao) is false)
                    query.Append($"ORDER BY {ordenacao} ");
                if (string.IsNullOrEmpty(paginacao) is false && ordenacaoExecutada)
                    query.Append(paginacao);
                return query.ToString().Trim();
            }
        }

        public QueryCreator(string nomeTabela)
        {
            this.nomeTabela = nomeTabela;
            ordenacaoExecutada = false;
        }

        public string GetQuery()
        {
            return query;
        }
        private string GetColuna()
        {
            return string.IsNullOrEmpty(colunas) ? "*" : colunas;
        }
        public QueryCreator Colunas(params string[] args)
        {
            colunas = string.Join(", ", args);
            return this;
        }
        public QueryCreator Paginacao(int numeroPagina, int linhaPorPagina)
        {
            var offsetNumber = (numeroPagina - 1) * linhaPorPagina;
            paginacao = $"OFFSET {offsetNumber} ROWS FETCH NEXT {linhaPorPagina} ROWS ONLY";
            return this;
        }
        public QueryCreator Ordenacao(string coluna, string ordem)
        {
            ordenacao = $"{coluna} {ordem}";
            ordenacaoExecutada = true;
            return this;
        }
        public QueryCreator Search(string pesquisa, params string[] colunas)
        {
            foreach (string coluna in colunas)
            {
                filtro += $"{coluna} LIKE '%{pesquisa}%' OR ";
            }

            filtro = filtro[0..^3];
            return this;
        }
    }
    public enum OrdemColunaEnum
    {
        Decrescente = 1,
        Crescente = 2
    }
}