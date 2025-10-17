using Microsoft.EntityFrameworkCore;
using ProjetoUm.Models;

namespace ProjetoUm.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Personagem> DBZ { get; set; } //criando um banco de daos, com o nome DBZ e uma tabela Personagem que do model
        
    }
}