﻿namespace Baas.Domain.Repositories.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
    }
}