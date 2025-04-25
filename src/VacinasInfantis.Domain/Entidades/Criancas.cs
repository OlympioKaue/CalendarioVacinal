using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace VacinasInfantis.Domain.Entidades;

public class Criancas
{
    /// <summary>
    /// O banco de dados é responsável por gerar o Id.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Nome da criança registrada.
    /// </summary>
    [Required(ErrorMessage = "O nome da criança é obrigatório")]
    [StringLength(50, MinimumLength = 7, ErrorMessage = "Este campo deve ter entre 7 a 50 caractere")]
    public string NomeDaCrianca { get; set; } = string.Empty;

    /// <summary>
    /// Data de nascimento da criança, aceita somente datas válidas.
    /// </summary>
    [Required]
    [DataType(DataType.Date)]
    public DateTime DataDeNascimentoDaCrianca { get; set; }

    /// <summary>
    /// Nome da mãe registrada.
    /// </summary>
    [Required(ErrorMessage = "O nome da mãe é obrigatório")]
    [StringLength(50, MinimumLength = 7, ErrorMessage = "Este campo deve ter entre 7 a 50 caractere")]
    public string NomeDaMae { get; set; } = string.Empty;

    /// <summary>
    /// Nome do pai registrado, é opcional, pode ser nullo.
    /// </summary>
    public string NomeDoPai { get; set; } = string.Empty;

    /// <summary>
    /// Email registrado do responsável pela criança.
    /// </summary>
    [Required (AllowEmptyStrings = false, ErrorMessage = "O e-mail do responsável deve ser informado.")]
    [EmailAddress(ErrorMessage = "O e-mail do responsável deve ser um endereço de e-mail válido")]
    public string? EmailResponsavel { get; set; }


    // Relacionamento com vacinas tomadas pela criança
    public List<Vacinas> Vacinas { get; set; } = new();



}
