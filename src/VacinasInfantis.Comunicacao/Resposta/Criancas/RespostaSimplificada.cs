using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VacinasInfantis.Comunicacao.Resposta.Criancas;

public class RespostaSimplificada
{
    [JsonPropertyName("ID Da Vacina")]
    public int Id { get; set; }

    [JsonPropertyName("Nome da Vacina")]
    public string NomeDaVacina { get; set; } = string.Empty;


    [JsonPropertyName("Idade Meses Da Aplicacao")]
    public long MesAplicacao { get; set; }

   






}
