using System.Text.Json.Serialization;

namespace VacinasInfantis.Comunicacao.Resposta.Criancas;

public class RespostaDeRegistroVacinas
{
    [JsonPropertyName("ID Da Vacina")]
    public long Id { get; set; }

    [JsonPropertyName("Nome da Vacina")]
    public string NomeDaVacina { get; set; } = string.Empty;

    [JsonPropertyName("Idade Meses Da Aplicacao")]
    public long MesAplicacao { get; set; }
}
