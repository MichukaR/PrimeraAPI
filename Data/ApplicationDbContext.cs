using Microsoft.EntityFrameworkCore;
using MiPrimeraAPIMichu.Modelos;

namespace MiPrimeraAPIMichu.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Ejemplo de DbSet
    public DbSet<Bicicleta> Bicicletas { get; set; }
}