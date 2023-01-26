using Baas.Domain.Repositories.DTOs;
using System;

namespace Baas.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }

        public static Account MappingFromDTO(AccountDTO conta)
        {
            return new Account()
            {
                Id = conta.Id,
                IdCliente = conta.IdCliente,
                Numero = conta.Numero,
                Tipo = conta.Tipo
            };
        }
    }
}