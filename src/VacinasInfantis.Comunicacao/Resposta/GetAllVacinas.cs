using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacinasInfantis.Comunicacao.Resposta;

public class GetAllVacinas
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public long MesAplicacao { get; set; }
}
