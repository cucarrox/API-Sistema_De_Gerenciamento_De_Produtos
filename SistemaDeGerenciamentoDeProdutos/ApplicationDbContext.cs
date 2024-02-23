using Microsoft.EntityFrameworkCore;
using SistemaDeGerenciamentoDeProdutos.Models;

namespace SistemaDeGerenciamentoDeProdutos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Produto> produtos { get; set; }
    }
}
