using Microsoft.EntityFrameworkCore;
using CadastroClientesAPI.Models;

namespace CadastroClientesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Tabelas
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        // Configuração extra (opcional)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define nomes curtos para o Oracle (máx. 30 caracteres)
            modelBuilder.Entity<Cliente>().ToTable("CLIENTE");
            modelBuilder.Entity<Endereco>().ToTable("ENDERECO");
        }
    }
}
