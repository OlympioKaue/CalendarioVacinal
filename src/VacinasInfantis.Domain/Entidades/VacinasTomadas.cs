namespace VacinasInfantis.Domain.Entidades;

public class VacinasTomadas
{
    public long Id { get; set; }
    public long CriancasId { get; set; }
    public long VacinasId { get; set; }
    public DateTime DataTomada { get; set; }

    public required Criancas Criancas { get; set; }
    public required VacinasCriancas Vacinas { get; set; }
}
