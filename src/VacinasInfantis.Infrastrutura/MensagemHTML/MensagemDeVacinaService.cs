namespace VacinasInfantis.Infrastrutura.MensagemHTML;

public static class MensagemDeVacinaService
{
    public static string GerarAssunto()
    {
        return "Lembrete de Vacinação";
    }

    public static string GerarMensagemHtml(string nomeCrianca, string dataVacina)
    {
        return $@"
<html>
  <body style='font-family: Arial, sans-serif; color: #333;'>
    <h2 style='color: #2E86C1;'>Lembrete de Vacinação</h2>
    <p>Olá responsável por <strong>{nomeCrianca}</strong>,</p>
    <p>
      Este é um lembrete para informar que a criança tem uma vacina prevista para o dia <strong>{dataVacina}</strong>.
    </p>
    <p>
      É importante manter a vacinação em dia para proteger a saúde da criança.
    </p>
    <p>
      Em caso de dúvidas, procure a Unidade de Saúde mais próxima.
    </p>
    <br/>
    <p>Atenciosamente,</p>
    <p><strong>Equipe de Saúde Infantil</strong></p>
  </body>
</html>";
    }
}

