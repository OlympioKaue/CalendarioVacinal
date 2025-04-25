using System.ComponentModel.DataAnnotations;

namespace VacinasInfantis.Domain.Entidades;

public class Profissionais
{
    /// <summary>
    /// O banco de dados é responsável por gerar o Id.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Nome do profissional de saúde registrado.
    /// </summary>
    [Required(ErrorMessage = "O nome do profissional é obrigatório")]
    [StringLength(50, MinimumLength = 7, ErrorMessage = "Este campo deve ter entre 7 a 50 caractere")]
    public string NomeProfissional { get; set; } = string.Empty;

    /// <summary>
    /// Registro Nacional do Profissional (CREFITO, CRM, CRO, etc), Aceita somente 7 válidos pelo (COREN).
    /// </summary>
    [Required]
    [RegularExpression(@"^d{7}$", ErrorMessage = "O registro deve ter exatamente 7 dígitos.")]
    public string RegistroProfissional { get; set; } = string.Empty;

    /// <summary>
    /// Nome da unidade de saúde onde o profissional atua.
    /// </summary>
    [Required(ErrorMessage = "O nome da unidade De Saúde é obrigatório")]
    [StringLength(50, MinimumLength = 7, ErrorMessage = "Este campo deve ter entre 7 a 50 caractere")]
    public string UnidadeSaude { get; set; } = string.Empty;


    // Relacionamento com vacinas aplicadas
    public List<Vacinas> Vacinas { get; set; } = new();  // Relacionamento com Vacinas.
   






}
