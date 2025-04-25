using System.Text.Json.Serialization;

namespace VacinasInfantis.Comunicacao.Requisicao.Enfermagem;

public class RegistroProfissionaisSaude
{
    [JsonPropertyName("Nome Do Profissional De Saúde")]
    public string? Nome { get; set; }

    [JsonPropertyName("Registro Profissional")]
    public string? Coren { get; set; } 

    [JsonPropertyName("Unidade De Saude")]
    public string? UnidadeSaude { get; set; }
}
    