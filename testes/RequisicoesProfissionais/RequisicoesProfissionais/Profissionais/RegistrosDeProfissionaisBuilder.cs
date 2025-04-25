using Bogus;
using VacinasInfantis.Comunicacao.Requisicao.Enfermagem;

namespace RequisicoesProfissionais.Profissionais;

public class RegistrosDeProfissionaisBuilder
{
    public static RegistroProfissionaisSaude Builder()
    {
        var faker = new Faker();
        return new Faker<RegistroProfissionaisSaude>()
        .RuleFor(x => x.Nome, faker => faker.Name.FullName())
        .RuleFor(x => x.Coren, faker => faker.Random.Number(1000000, 9999999).ToString())
        .RuleFor(x => x.UnidadeSaude, faker => faker.Company.CompanyName());
    }



    

}
