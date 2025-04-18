using Microsoft.EntityFrameworkCore;
using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Infrastrutura.DataBaseAcesso;

public class VacinaInfantilDbContext : DbContext
{

    public VacinaInfantilDbContext(DbContextOptions option) : base(option)
    {
    }
    public DbSet<Criancas> Criancas { get; set; }
    public DbSet<Vacinas> Vacinas { get; set; }
    public DbSet<Profissionais> Profissionais { get; set; }
    public DbSet<CalendarioDeVacinas> CalendarioDeVacinas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relacionamento entre Vacinas e Criancas
        modelBuilder.Entity<Vacinas>()
        .HasOne(v => v.Crianca)  
        .WithMany(v => v.Vacinas)  
        .HasForeignKey(v => v.CriancasId)
        .OnDelete(DeleteBehavior.Cascade);// Quando deletar uma criança, deleta as vacinas dela

        // Relacionamento entre Vacinas e Profissionais
        modelBuilder.Entity<Vacinas>()
        .HasOne(v => v.ProfissionalSaude)
        .WithMany(v => v.Vacinas)
        .HasForeignKey(v => v.ProfissionalSaudeId)
        .OnDelete(DeleteBehavior.Restrict); // Não permite deletar um profissional que aplicou vacinas


    }

}
