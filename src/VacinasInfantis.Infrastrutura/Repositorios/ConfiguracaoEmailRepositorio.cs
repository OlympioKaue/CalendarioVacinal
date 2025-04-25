namespace VacinasInfantis.Infrastrutura.Repositorios;

public class ConfiguracaoEmailRepositorio
{
    public string Remetente { get; set; } = string.Empty;
    public string SenhaApp { get; set; } = string.Empty;
    public string SmtpServidor { get; set; } = string.Empty;
    public int SmtpPorta { get; set; }
}
