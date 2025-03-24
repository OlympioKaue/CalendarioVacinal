using Microsoft.EntityFrameworkCore;
using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Infrastrutura.DataBaseAcesso;

public class VacinaInfantilDbContext : DbContext
{

    public VacinaInfantilDbContext(DbContextOptions option) : base(option)
    {
        
    }


    public DbSet<Criancas> Criancas { get; set; }
    public DbSet<VacinasCriancas> VacinasCriancas { get; set; }
    public DbSet<VacinasTomadas> VacinasTomadas { get; set; }
}
