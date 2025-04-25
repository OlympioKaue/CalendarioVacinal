using System.Net;

namespace VacinasInfantis.Excecao.BaseDaExcecao;

public class Excecoes : VacinaisInfantisExcecao
{
    // Classe especifica para pegas os erros e trata-los como BaddRequest

    private readonly List<string> _erroDeExcecaoModificada;

    public Excecoes(List<string> erros) : base (string.Empty) // esse base evita que o SystemException seja chamado
    {
        _erroDeExcecaoModificada = erros;
    }

    public Excecoes(string erro) : base(erro)
    {
        _erroDeExcecaoModificada = new List<string> { erro };
    }

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public override List<string> ObterErros()
    {
        return _erroDeExcecaoModificada;
    }
}
