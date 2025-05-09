﻿using Microsoft.Extensions.DependencyInjection;
using VacinasInfantis.Aplicacao.AutoMapper;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.AtualizarCriancas;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.DeletarCriancas;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.ObterCriancas;
using VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.RegistrarCrianca;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.AtualizarProfissionais;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.DeletarProfissionais;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.ObterProfissionalAplicadorID;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.Registro;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.AtualizarVacinas;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.DeletarVacinas;
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
        services.AddScoped<IObterVacinasPorIdDaCrianca, ObterVacinasPorIdDaCrianca>();
        services.AddScoped<IRegistrosDeCriancas, RegistrosDeCriancas>();
        services.AddScoped<IRegistroDeImunizantes, RegistroDeImunizantes>();
        services.AddScoped<IObterVacinasAtuais_Proximas, ObterVacinasAtuais_Proximas>();
        services.AddScoped<IRegistroEnfermagem, RegistroEnfermagem>();
        services.AddScoped<IObterProfissionalAplicador, ObterProfissionalAplicador>();
        services.AddScoped<IObterCriancasRegistradas, ObterCriancasRegistradas>();
        services.AddScoped<IAtualizacaoDeCriancas, AtualizacaoDeCriancas>();
        services.AddScoped<IDeletarCriancas, DeletarCriancas>();
        services.AddScoped<IAtualizacaoDeProfissionaisEnfermagem, AtualizacaoDeProfissionaisEnfermagem>();
        services.AddScoped<IDeletarProfissionaisEnfermagem, DeletarProfissionaisEnfermagem>();
        services.AddScoped<IAtualizarImunizantes, AtualizarImunizantes>();
        services.AddScoped<IDeletarImunizantes, DeletarImunizantes>();
    }
}
