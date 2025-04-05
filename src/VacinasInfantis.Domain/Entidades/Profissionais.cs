using System.ComponentModel.DataAnnotations;

namespace VacinasInfantis.Domain.Entidades;

public class Profissionais
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string NomeProfissional { get; set; } = string.Empty;

    [Required]
    public long RegistroProfissional { get; set; }

    [Required]
    public string UnidadeSaude { get; set; } = string.Empty;


    // Relacionamento com vacinas aplicadas
    public List<Vacinas> Vacinas { get; set; } = new();  // Relacionamento com Vacinas.
   






}
