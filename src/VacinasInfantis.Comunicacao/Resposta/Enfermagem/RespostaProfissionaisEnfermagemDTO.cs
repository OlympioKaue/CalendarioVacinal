using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VacinasInfantis.Comunicacao.Resposta.Enfermagem;

public class RespostaProfissionaisEnfermagemDTO
{
   public int Id { get; set; }
    public string NomeProfissional { get; set; } = string.Empty;
    public long RegistroProfissional { get; set; }
    public string UnidadeSaude { get; set; } = string.Empty;
    public List<CriancaVacinadaProfissional> CriancaVacinada { get; set; } = new(); // Lista de crianças vacinadas

}
