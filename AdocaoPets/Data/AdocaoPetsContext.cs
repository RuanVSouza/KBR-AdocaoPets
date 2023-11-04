using AdocaoPets.Models;
using Microsoft.EntityFrameworkCore;

namespace AdocaoPets.Data;

public class AdocaoPetsContext : DbContext
{
    
    public AdocaoPetsContext (DbContextOptions<AdocaoPetsContext> options)
        : base(options)
    {
    }
    
    public DbSet<Admin> Admin { get; set; }
    public DbSet<Animal> Animal { get; set; }
    public DbSet<Solicitante> Solicitante { get; set; }
}