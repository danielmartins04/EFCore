using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Database
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<EnderecoEntrega> EnderecosEntrega { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { Id = 1, Nome = "Moda" },
                new Departamento { Id = 2, Nome = "Mercado" },
                new Departamento { Id = 3, Nome = "Informática" },
                new Departamento { Id = 4, Nome = "Eletrodomésticos" },
                new Departamento { Id = 5, Nome = "Beleza" }
            );
        }
    }
}
