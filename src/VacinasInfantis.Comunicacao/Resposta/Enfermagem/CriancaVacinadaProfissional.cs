using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VacinasInfantis.Comunicacao.Resposta.Enfermagem;

public class CriancaVacinadaProfissional
{
    [JsonPropertyName("Nome Da Criança")]
    public string NomeDaCrianca { get; set; } = string.Empty;
}
