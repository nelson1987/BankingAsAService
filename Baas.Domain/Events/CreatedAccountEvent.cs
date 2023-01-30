using MediatR;

namespace Baas.Domain.Events
{
    public interface ICreatedAccountEvent : INotification
    {
    }

    public class CreatedAccountEvent : ICreatedAccountEvent
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
        public int IdEnterpriseAccount { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }

        //public static CreatedAccountEvent MappingFromModel(Entities.Account conta)
        //{
        //    return new CreatedAccountEvent()
        //    {
        //        Id = conta.Id,
        //        IdCliente = conta.IdCliente,
        //        Numero = conta.Numero,
        //        Tipo = conta.Tipo,
        //    };
        //}
    }
}