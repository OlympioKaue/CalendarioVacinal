using System.Text.Json.Serialization;

namespace VacinasInfantis.Comunicacao.Resposta.Vacinas;

public class RespostaRegistroVacinas
{

    [JsonPropertyName("Nome da Vacina")]
    public string NomeDaVacina { get; set; } = string.Empty;

    [JsonPropertyName("Data De Aplicacao Da Vacina")]
    public DateTime DataAplicacao { get; set; }
   

}
