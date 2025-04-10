using System.Text.Json.Serialization;

namespace VacinasInfantis.Comunicacao.Resposta.Enfermagem;

public class RespostaRegistroEnfermagem
{
    [JsonPropertyName("Nome do Profissional De Saúde")]
    public string? NomeProfissional { get; set; }

    [JsonPropertyName("Unidade de Saúde")]
    public string UnidadeSaude { get; set; } = string.Empty;
}
