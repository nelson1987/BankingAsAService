using System;

namespace Baas.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Criacao { get; set; }
        public string Documento { get; set; }
        public string Tipo { get; set; }
    }
}
