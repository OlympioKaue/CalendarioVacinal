using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VacinasInfantis.Comunicacao.Resposta.Criancas;

public class RespostaSimplificada
{
    public int Id { get; set; }

    public string NomeDaVacina { get; set; } = string.Empty;


    [JsonPropertyName("IdadeMeses")]
    public long MesAplicacao { get; set; }

   






}
