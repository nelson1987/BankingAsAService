using MediatR;

namespace Baas.Domain.Account.CreatedAccount
{
    public class CreatedAccountEvent : INotification
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
        public int IdEnterpriseAccount { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
    }
}