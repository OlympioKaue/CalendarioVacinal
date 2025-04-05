using System.Text.Json.Serialization;

namespace VacinasInfantis.Comunicacao.Resposta.Criancas;

public class RespostaDeRegistroVacinas
{
    public long Id { get; set; }
    public string NomeDaVacina { get; set; } = string.Empty;

    [JsonPropertyName("IdadeMeses")]
    public long MesAplicacao { get; set; }
}
