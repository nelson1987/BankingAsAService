using MediatR;

namespace Baas.Domain.Events
{
    public class CriarContaCorrenteEvent : INotification
    {
        public int Id { get; set; }
        public string NumeroConta { get; set; }
        public decimal Saldo { get; set; }
    }
}
