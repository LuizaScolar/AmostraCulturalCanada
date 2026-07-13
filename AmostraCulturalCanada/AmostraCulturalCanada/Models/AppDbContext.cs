using Microsoft.EntityFrameworkCore;

namespace AmostraCulturalCanada.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Isso diz ao Entity Framework para criar uma tabela chamada "Usuarios" baseada no modelo acima
        public DbSet<Usuario> Usuarios { get; set; }
    }
}