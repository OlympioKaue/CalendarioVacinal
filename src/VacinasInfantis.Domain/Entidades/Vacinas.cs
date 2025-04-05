using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacinasInfantis.Domain.Entidades;

[Table("VacinasCriancas")]
public class Vacinas 
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string NomeDaVacina { get; set; } = string.Empty;

    [Required]
    public long MesAplicacao { get; set; }

    public DateTime DataAplicacao { get; set; }

    // Chave estrangeira para Criancas
    public int CriancasId { get; set; }
    [ForeignKey("CriancasId")]
    public Criancas? Crianca { get; set; }

    // Chave estrangeira para Profissionais
    public int ProfissionalSaudeId { get; set; }
    [ForeignKey("ProfissionalSaudeId")]
    public Profissionais? ProfissionalSaude { get; set; }



}
