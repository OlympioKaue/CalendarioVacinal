using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VacinasInfantis.Comunicacao.Resposta.Enfermagem;

public class RespostaProfissionaisEnfermagemDTO
{
    [JsonPropertyName("ID Do Profissional De Saúde")]
    public int Id { get; set; }

    [JsonPropertyName("Nome do Profissional de Saúde")]
    public string NomeProfissional { get; set; } = string.Empty;

    [JsonPropertyName("Registro Do Profissional")]
    public string? RegistroProfissional { get; set; }

    [JsonPropertyName("Unidade De Saúde")]
    public string UnidadeSaude { get; set; } = string.Empty;


    [JsonPropertyName("Crianca Vacinada")]
    public List<CriancaVacinadaProfissional> CriancaVacinada { get; set; } = new(); // Lista de crianças vacinadas

}
