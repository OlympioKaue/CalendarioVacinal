using RequisicoesProfissionais.Profissionais;
using Shouldly;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.Validacoes;

namespace TestesUnitarios.Profissionais;

public class ValidarRequisicoesDeEnfermagem
{

    [Fact]
    public void RequisicaoDeSucesso()
    {
        //Arrange
        var validar = new ValidarRegistrosDeEnfermagem();
        var builder = RegistrosDeProfissionaisBuilder.Builder();
        //Act
        var resultado = validar.Validate(builder);
        //Assert
        resultado.IsValid.ShouldBeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData(null)]
    public void RequisicaoDeFalhaNome(string nome)
    {
        //Arrange
        var validar = new ValidarRegistrosDeEnfermagem();
        var builder = RegistrosDeProfissionaisBuilder.Builder();
        builder.Nome = nome;

        //Act
        var resultado = validar.Validate(builder);

        //Assert
        resultado.IsValid.ShouldBeFalse();
    }

    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData(null)]
    public void RequisicaoDeFalhaUnidadeSaude(string unidadeSaude)
    {
        //Arrange
        var validar = new ValidarRegistrosDeEnfermagem();
        var builder = RegistrosDeProfissionaisBuilder.Builder();
        builder.UnidadeSaude = unidadeSaude;

        //Act
        var resultado = validar.Validate(builder);

        //Assert
        resultado.IsValid.ShouldBeFalse();
    }


    [Theory]
    [InlineData("123456789")]
    [InlineData("1")]
    [InlineData(null)]
    public void RequisicaoDeFalhaCoren(string numero)
    {
        //Arrange
        var validar = new ValidarRegistrosDeEnfermagem();
        var builder = RegistrosDeProfissionaisBuilder.Builder();
        builder.Coren = numero;

        //Act
        var resultado = validar.Validate(builder);

        //Assert
        resultado.IsValid.ShouldBeFalse();
    }
}
