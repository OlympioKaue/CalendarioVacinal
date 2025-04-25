using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacinasInfantis.Domain.Entidades;

[Table("VacinasCriancas")]
public class Vacinas 
{
    /// <summary>
    /// O banco de dados é responsável por gerar o Id.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Nome da vacina aplicada.
    /// </summary>
    [Required(ErrorMessage = "O nome da vacina é obrigatório")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Este campo deve ter entre 2 a 100 caractere")]
    public string NomeDaVacina { get; set; } = string.Empty;

    /// <summary>
    /// Aceita somente valores int de 0 a 48 meses.
    /// </summary>
    [Required]
    [Range(0,48, ErrorMessage = "A idade deve estar entre 0 e 48 meses.")]
    public long MesAplicacao { get; set; }

    /// <summary>
    /// É obrigatório informar a data de aplicação da vacina com data e hora.
    /// </summary>
    [Required]
    [DataType(DataType.DateTime)]
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
