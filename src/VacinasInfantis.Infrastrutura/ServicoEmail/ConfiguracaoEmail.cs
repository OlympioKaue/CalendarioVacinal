namespace VacinasInfantis.Infrastrutura.ServicoEmail;

public class ConfiguracaoEmail
{
    public string Remetente { get; set; } = string.Empty;
    public string SenhaApp { get; set; } = string.Empty;
    public string SmtpServidor { get; set; } = string.Empty;
    public int SmtpPorta { get; set; }
}
