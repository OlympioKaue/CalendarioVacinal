using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace VacinasInfantis.Domain.Entidades;

public class Criancas
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string NomeDaCrianca { get; set; } = string.Empty;

    [Required]
    public DateTime DataDeNascimentoDaCrianca { get; set; }

    [Required]
    public string NomeDaMae { get; set; } = string.Empty;

    [Required]
    public string NomeDoPai { get; set; } = string.Empty;

    [Required]
    public string EmailResponsavel { get; set; } = string.Empty;
  

    // Relacionamento com vacinas tomadas pela criança
    public List<Vacinas> Vacinas { get; set; } = new();



}
