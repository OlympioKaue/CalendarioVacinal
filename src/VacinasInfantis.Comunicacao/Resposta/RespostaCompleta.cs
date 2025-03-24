using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VacinasInfantis.Comunicacao.Resposta;

public class RespostaCompleta
{
    public List<RespostaVacinas> Vacinas { get; set; } = [];
}
