using BAAS.Domain.Produces;

namespace Baas.Domain.Events
{
    //public class CreatedAccountEvent : ICreatedAccountEvent
    //{
    //    public void Init(IEvent<CreatedAccountEvent> message)
    //    {

    //    }
    //}
    //public interface ICreatedAccountEvent : IProduceMessage<CreatedAccountEvent>
    //{

    //}

    public class CreatedAccountEvent 
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