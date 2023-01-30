namespace Baas.Domain.Entities
{
    public class Conta
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Agencia { get; set; }
        public string CodigoCompe { get; set; }
        public decimal Saldo { get; set; }
    }
}