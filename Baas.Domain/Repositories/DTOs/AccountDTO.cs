using Baas.Domain.Commands;
using System;

namespace Baas.Domain.Repositories.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
        public string Agencia { get; set; }

        internal static AccountDTO MappingFromModel(AberturaContaCommand request)
        {
            return new AccountDTO()
            {
                Agencia = request.Agencia,
                IdCliente = request.IdCliente,
                Tipo = request.Tipo
            };
        }
        //public int IdEnterpriseAccount { get; set; }
        //public string Name { get; set; }
        //public string Document { get; set; }
        //public string Agencia { get; set; }
        //public string CodigoCompe { get; set; }
    }
}