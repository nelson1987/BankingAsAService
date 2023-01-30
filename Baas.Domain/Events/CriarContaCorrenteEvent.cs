using MediatR;

namespace Baas.Domain.Entities
{
    public class CriarContaCorrenteEvent : INotification
    {
        public int Id { get; set; }
        public string NumeroConta { get; set; }
        public decimal Saldo { get; set; }
    }
}
