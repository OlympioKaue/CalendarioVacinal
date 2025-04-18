using Microsoft.Extensions.DependencyInjection;
using VacinasInfantis.Aplicacao.AutoMapper;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.ObterCriancas;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.RegistrarCrianca;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.ObterProfissionalAplicadorID;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.Registro;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinas;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasAtuais_Proximas;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasId;
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
        services.AddScoped<IObterVacinasInfantisIdade, ObterVacinasInfantisIdade>();
        services.AddScoped<IRegistrosDeCriancas, RegistrosDeCriancas>();
        services.AddScoped<IRegistroDeImunizantes, RegistroDeImunizantes>();
        services.AddScoped<IObterVacinasAtuais_Proximas, ObterVacinasAtuais_Proximas>();
        services.AddScoped<IRegistroEnfermagem, RegistroEnfermagem>();
        services.AddScoped<IObterProfissionalAplicador, ObterProfissionalAplicador>();
        services.AddScoped<IObterCriancasRegistradas, ObterCriancasRegistradas>();
    
       




        // Extensão de Injeção de Dependência //

    }
}
