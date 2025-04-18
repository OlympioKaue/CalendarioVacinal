using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacinasInfantis.Domain.Entidades;

public class CalendarioDeVacinas
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string NomeDaVacina { get; set; } = string.Empty;

    [Required]
    public long MesAplicacao { get; set; }

   
}
