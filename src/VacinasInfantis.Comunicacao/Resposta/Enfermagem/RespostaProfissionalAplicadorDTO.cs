using System.Text.Json.Serialization;

namespace VacinasInfantis.Comunicacao.Resposta.Enfermagem;

public class RespostaProfissionalAplicadorDTO
{
    [JsonPropertyName("Enfermagem")]
    public List<RespostaProfissionaisEnfermagemDTO> Enfermagem { get; set; } = [];
     

}
