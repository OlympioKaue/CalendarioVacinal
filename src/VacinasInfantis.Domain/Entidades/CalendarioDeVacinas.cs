using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacinasInfantis.Domain.Entidades;

public class CalendarioDeVacinas
{
    /// <summary>
    /// Identificador único da vacina.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Nome da Vacina.
    /// </summary>
    public string NomeDaVacina { get; set; } = string.Empty;

    /// <summary>
    /// Mês de aplicação da vacina, validos de 0 a 48 meses.
    /// </summary>
    public long MesAplicacao { get; set; }

   
}
