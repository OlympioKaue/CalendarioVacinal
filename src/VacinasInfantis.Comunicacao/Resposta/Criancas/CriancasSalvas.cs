using System.Text.Json.Serialization;

namespace VacinasInfantis.Comunicacao.Resposta.Criancas;

public class CriancasSalvas
{
    [JsonPropertyName("ID Da Criança")]
    public long Id { get; set; }

    [JsonPropertyName("Nome da Criança")]
    public string NomeDaCrianca { get; set; } = string.Empty;

    [JsonPropertyName("Nome da Mãe")]
    public string NomeDaMae {  get; set; } = string.Empty;

    [JsonPropertyName("Nome do Pai(Opcional)")]
    public string NomeDoPai { get; set; } = string.Empty;


}
