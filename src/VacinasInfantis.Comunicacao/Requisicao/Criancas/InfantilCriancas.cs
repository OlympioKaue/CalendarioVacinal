using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VacinasInfantis.Comunicacao.Requisicao.Criancas;

public class InfantilCriancas
{
    [JsonPropertyName("Nome da Criança")]
    public string NomeDaCrianca { get; set; } = string.Empty;

    [JsonPropertyName("Nome da Mãe")]
    public string NomeDaMae { get; set; } = string.Empty;

    [JsonPropertyName("Nome do Pai(Opcional)")]
    public string NomeDoPai { get; set; } = string.Empty;

    [JsonPropertyName("Data De Nascimento Da Criança")]
    public DateTime DataDeNascimentoDaCrianca { get; set; }

    [Required]
    public string? EmailResponsavel { get; set; }


}
