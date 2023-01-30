using Baas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Baas.Infra.DbContext
{
    public class MyDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<CartaoCredito> Cartoes { get; set; }
        public DbSet<Investimento> Investimentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BancoDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Cliente>().Property(p => p.Id).HasColumnName("IdCliente");
            modelBuilder.Entity<Cliente>().Property(p => p.Nome).HasColumnName("Nome");

            modelBuilder.Entity<Conta>().ToTable("Conta");
            modelBuilder.Entity<Conta>().Property(p => p.Id).HasColumnName("IdConta");
            modelBuilder.Entity<Conta>().Property(p => p.Saldo).HasColumnName("Saldo");

            modelBuilder.Entity<CartaoCredito>().ToTable("Cartao");
            modelBuilder.Entity<CartaoCredito>().Property(p => p.Id).HasColumnName("IdCartao");
            modelBuilder.Entity<CartaoCredito>().Property(p => p.NumeroCartao).HasColumnName("Numero");

            modelBuilder.Entity<Investimento>().ToTable("Investimento");
            modelBuilder.Entity<Investimento>().Property(p => p.Id).HasColumnName("IdInvestimento");
            modelBuilder.Entity<Investimento>().Property(p => p.Saldo).HasColumnName("Valor");
        }
    }
}
