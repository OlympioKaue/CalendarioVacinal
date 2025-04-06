namespace VacinasInfantis.Excecao.BaseDaExcecao;

public class ExcecaoModificada : VacinaisInfantisExcecao
{
    // Classe especifica para pegas os erros e trata-los

    private readonly List<string> _erros;

    public ExcecaoModificada(List<string> erros)
    {
        _erros = erros;
    }

}
