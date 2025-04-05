namespace VacinasInfantis.Comunicacao.Requisicao.Vacinas;

public class RegistroDeVacinas
{
    public string NomeDaVacina { get; set; } = string.Empty;
    public long DataDeAplicacao { get; set; }
    public DateTime DataAplicacao { get; set; }
    public int ProfissionalSaudeId { get; set; }
}
