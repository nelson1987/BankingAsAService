namespace Baas.Domain.Entities
{
    public class ContaCorrente
    {
        public int Id { get; set; }
        public string NumeroConta { get; set; }
        public decimal Saldo { get; set; }

        public void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public void Sacar(decimal valor)
        {
            Saldo -= valor;
        }

        public void Transferir(ContaCorrente contaDestino, decimal valor)
        {
            Sacar(valor);
            contaDestino.Depositar(valor);
        }
    }
}
