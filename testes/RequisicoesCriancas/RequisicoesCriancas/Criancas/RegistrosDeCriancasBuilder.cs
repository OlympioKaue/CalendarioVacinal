using Bogus;
using VacinasInfantis.Comunicacao.Requisicao.Criancas;

namespace RequisicoesCriancas.Criancas;

public class RegistrosDeCriancasBuilder
{
    public static RegistrarCriancas Builder()
    {
        var faker = new Faker();
        return new Faker<RegistrarCriancas>()
            .RuleFor(x => x.NomeDaCrianca, faker => faker.Name.FullName())
            .RuleFor(x => x.NomeDaMae, faker => faker.Name.FullName())
            .RuleFor(x => x.NomeDoPai, faker => faker.Name.FullName())
            .RuleFor(x => x.DataDeNascimentoDaCrianca, faker => faker.Date.Past(2))
            .RuleFor(x => x.EmailResponsavel, faker => faker.Internet.Email());
    }

}
