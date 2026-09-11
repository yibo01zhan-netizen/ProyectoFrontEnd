using Api_Plataforma_DB.Models;
using Microsoft.EntityFrameworkCore;
namespace Api_Plataforma_DB.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Producto> Producto { get; set; }
    }
} 