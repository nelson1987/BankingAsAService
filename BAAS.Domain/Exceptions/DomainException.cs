using System;
using System.Reflection;

namespace Baas.Domain.Exceptions
{
    //public class HttpDomainException : DomainException
    //{
    //    public HttpDomainException(string erro) : base(erro)
    //    {
    //    }
    //}

    //public class DomainException
    //{
    //    public string Erro { get; set; }

    //    public DomainException(string erro)
    //    {
    //        Erro = erro;
    //    }
    //}

    public class ErroPadrao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Mensagem { get; set; }

        public ErroPadrao(ErroPadraoEnum erroPadrao)
        {
            var type = erroPadrao.GetType();
            var member = type.GetMember(erroPadrao.ToString());
            var attribute = member[0].GetCustomAttribute<ErroPadraoAttribute>();
            Id = (int)erroPadrao;
            Descricao = erroPadrao.ToString();
            Mensagem = attribute.Mensagem;
        }
    }

    public enum ErroPadraoEnum
    {
        [ErroPadrao("Valor inválido")]
        VALOR_INVALIDO,

        [ErroPadrao("Nota inválida")]
        NOTA_INVALIDA,

        [ErroPadrao("Erro de sistema")]
        ERRO_SISTEMA
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class ErroPadraoAttribute : Attribute
    {
        public string Mensagem { get; set; }

        public ErroPadraoAttribute(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}