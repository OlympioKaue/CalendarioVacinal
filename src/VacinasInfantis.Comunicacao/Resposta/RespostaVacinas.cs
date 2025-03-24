using System.Text.Json.Serialization;

namespace VacinasInfantis.Comunicacao.Resposta;

public class RespostaVacinas
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("IdadeMeses")]
    public long MesAplicacao { get; set; }
}
