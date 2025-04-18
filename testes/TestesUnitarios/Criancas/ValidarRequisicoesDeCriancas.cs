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

}
