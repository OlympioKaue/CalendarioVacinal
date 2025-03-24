using Microsoft.Extensions.DependencyInjection;
using VacinasInfantis.Aplicacao.AutoMapper;
using VacinasInfantis.Aplicacao.UseCase.Vacinas.ObterVacinas;
using VacinasInfantis.Aplicacao.UseCase.Vacinas.ObterVacinasIdade;

namespace VacinasInfantis.Aplicacao.ExtensaoDependencia;

public static class ExtensaoInjecaoDependencia
{
    public static void AdicionarAplicacao(this IServiceCollection services)
    {
       AdicionarUseCase(services);
       AdicionarInjecaoDependencia(services);
    }

    private static void AdicionarInjecaoDependencia(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ArquivosMapeados));
    }

    private static void AdicionarUseCase(this IServiceCollection services)
    {
        services.AddScoped<IGetVacinasInfantisUseCase, GetVacinasInfantisUseCase>();
        services.AddScoped<IGetVacinasInfantisIdadeUseCase, GetVacinasInfantisIdadeUseCase>();
    }
}
