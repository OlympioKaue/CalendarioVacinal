using System.Text.Json.Serialization;

namespace VacinasInfantis.Comunicacao.Requisicao.Vacinas;

public class RegistroDeVacinas
{
    [JsonPropertyName("Nome da Vacina")]
    public string NomeDaVacina { get; set; } = string.Empty;

    [JsonPropertyName("Idade Mêses da Criança")]
    public long DataDeAplicacao { get; set; }

    [JsonPropertyName("Data De Aplicação")]
    public DateTime DataAplicacao { get; set; }

    [JsonPropertyName("ID Do Profissional de Saúde")]
    public int ProfissionalSaudeId { get; set; }
}
