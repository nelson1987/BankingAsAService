namespace Baas.Domain.Exceptions
{
    public class HttpDomainException : DomainException
    {
        public HttpDomainException(string erro) : base(erro)
        {
        }
    }
    public class DomainException
    {
        public string Erro { get; set; }
        public DomainException(string erro)
        {
            Erro = erro;
        }
    }
    public static class ErroPadrao
    {
        public static DomainException Teste { get { return new DomainException("Testo do Erro"); } }
    }
}
