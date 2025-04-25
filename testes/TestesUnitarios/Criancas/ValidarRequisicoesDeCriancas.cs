using RequisicoesCriancas.Criancas;
using Shouldly;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.Validacoes;

namespace TestesUnitarios.Criancas;

public class ValidarRequisicoesDeCriancas
{
    [Fact]
    public void RequisicaoDeSucesso()
    {   
        //Arrange
        var validar = new ValidarRegistrosDeCriancas();
        var builder = RegistrosDeCriancasBuilder.Builder();

        //Act
        var resultado = validar.Validate(builder);

        //Assert
        resultado.IsValid.ShouldBeTrue();
    }


    [Fact]
    public void RequisicaoDeFalhaDataDeNascimento()
    {
        //Arrange
        var validar = new ValidarRegistrosDeCriancas();
        var builder = RegistrosDeCriancasBuilder.Builder();
        builder.DataDeNascimentoDaCrianca = DateTime.Now.AddYears(2);
        //Act
        var resultado = validar.Validate(builder);
        //Assert
        resultado.IsValid.ShouldBeFalse();
    }


    [Theory]
    [InlineData("", "")]
    [InlineData(" ", " ")]
    [InlineData(null, null)]
    public void RequisicaoDeFalhaPais_Maes(string nomeDaMae, string nomeDoPai)
    {
        //Arrange
        var validar = new ValidarRegistrosDeCriancas();
        var builder = RegistrosDeCriancasBuilder.Builder();
        builder.NomeDaMae = nomeDaMae;
        builder.NomeDoPai = nomeDoPai;

        //Act
        var resultado = validar.Validate(builder);

        //Assert
        resultado.IsValid.ShouldBeFalse();
    }

    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData(null)]
    [InlineData("teste@empresa.com.br")]
    [InlineData("testedeerro@net.org")]
    public void RequisicaoDeFalhaEmail(string email)
    {
        //Arrange
        var validar = new ValidarRegistrosDeCriancas();
        var builder = RegistrosDeCriancasBuilder.Builder();
        builder.EmailResponsavel = email;

        //Act
        var resultado = validar.Validate(builder);

        //Assert
        resultado.IsValid.ShouldBeFalse();
    }
}
