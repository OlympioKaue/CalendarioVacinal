using Microsoft.Extensions.DependencyInjection;
using VacinasInfantis.Aplicacao.AutoMapper;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.ObterCriancas;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.RegistrarCrianca;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.ObterProfissionalAplicador;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.Registro;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinas;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasIdade;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasProximas;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.Registro;

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
        services.AddScoped<IObterVacinasInfantis, GetVacinasInfantisUseCase>();
        services.AddScoped<IGetVacinasInfantisIdadeUseCase, ObterVacinasInfantisIdade>();
        services.AddScoped<IRegistrosDeCriancas, RegistrosDeCriancas>();
        services.AddScoped<IRegistroDeImunizantes, RegistroDeImunizantes>();
        services.AddScoped<IObterVacinasAtuais, ObterVacinasAtuais>();
        services.AddScoped<IRegistroEnfermagem, RegistroEnfermagem>();
        services.AddScoped<IObterProfissionalAplicador, ObterProfissionalAplicador>();
        services.AddScoped<IObterCriancasUseCase, ObterCriancasUseCase>();

        // Extensão de Injeção de Dependência //

    }
}
