using Bogus;
using VacinasInfantis.Comunicacao.Requisicao.Vacinas;

namespace RequisicoesVacinas.Vacinas;

public class RegistrosDeVacinasBuilder
{
    public static RegistroDeVacinas Builder()
    {
        var faker = new Faker();
        return new Faker<RegistroDeVacinas>()
            .RuleFor(x => x.NomeDaVacina, faker.Name.FullName())
            .RuleFor(x => x.DataDeAplicacao, faker.Random.Number(0, 48))
            .RuleFor(x => x.DataAplicacao, faker.Date.Past(1))
            .RuleFor(x => x.ProfissionalSaudeId, faker.Random.Number(1, 1));
    }

}
