using RequisicoesVacinas.Vacinas;
using Shouldly;
using System.Text.Json.Serialization;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.Validacoes;

namespace TestesUnitarios.Vacinas;

public class ValidarRequisicoesDeVacinas
{
    [Fact]
    public void SucessoNaRequisicaoDeVacinas()
    {
        //Arange
        var validar = new ValidarVacinasRegistradas();
        var builder = RegistrosDeVacinasBuilder.Builder();

        //Act 
        var resultado = validar.Validate(builder);

        //Assert
        resultado.IsValid.ShouldBeTrue();
    }


    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData(null)]
    public void RequisicoesDeFalhaNomeDaVacina(string nomedaVacina)
    {
        //Arange
        var validar = new ValidarVacinasRegistradas();
        var builder = RegistrosDeVacinasBuilder.Builder();
        builder.NomeDaVacina = nomedaVacina;

        //Act 
        var resultado = validar.Validate(builder);

        //Assert
        resultado.IsValid.ShouldBeFalse();
    }

    [Fact]
    public void RequisicoesDeFalhaMesDaCrianca()
    {
        //Arange
        var validar = new ValidarVacinasRegistradas();
        var builder = RegistrosDeVacinasBuilder.Builder();
        builder.DataDeAplicacao = -1;
      
        //Act 
        var resultado = validar.Validate(builder);
        

        //Assert
        resultado.IsValid.ShouldBeFalse();
    }


    [Fact]
    public void RequisicoesDeFalhaDataDeAplicacao()
    {
        //Arange
        var validar = new ValidarVacinasRegistradas();
        var builder = RegistrosDeVacinasBuilder.Builder();
        builder.DataAplicacao = DateTime.UtcNow.AddYears(2);

        //Act 
        var resultado = validar.Validate(builder);


        //Assert
        resultado.IsValid.ShouldBeFalse();
    }


}
