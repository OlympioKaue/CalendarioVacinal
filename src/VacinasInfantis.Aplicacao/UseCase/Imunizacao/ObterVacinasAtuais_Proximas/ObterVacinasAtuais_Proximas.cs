    using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;
using VacinasInfantis.Infrastrutura.DataBaseAcesso;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.ObterVacinasAtuais_Proximas;

public class ObterVacinasAtuais_Proximas : IObterVacinasAtuais_Proximas
{
    private readonly ILeituraVacinasRepositorio _leituraVacinas;
    private readonly IMapper _mapeamento;
    private readonly IEmailService _email;
    private readonly VacinaInfantilDbContext _dbContext;


    public ObterVacinasAtuais_Proximas(ILeituraVacinasRepositorio leituraVacinas, IMapper mapeamento, IEmailService email, VacinaInfantilDbContext dbContext)
    {
        _leituraVacinas = leituraVacinas;
        _mapeamento = mapeamento;
        _email = email;
        _dbContext = dbContext;
    }

    public async Task<RespostaVacinasInfantis> ObterMesAtual(int id)
    {
        // Obtem as vacinas do mês atual
        // Retorne as vacinas do mês atual


        var result = await _leituraVacinas.ObterVacinasAtual(id);
        if (result is null || result.Count == 0)
        {
            throw new NaoEncontrado("Nenhuma vacina encontrada para essa criança");
        }



        return new RespostaVacinasInfantis
        {
            Vacinas = _mapeamento.Map<List<RespostaSimplificada>>(result)
        };


    }

    public async Task<RespostaVacinasInfantis> ObterProximoMes(int id)
    {
        // Obtem as vacinas do próximo mês
        // Retorne as vacinas do próximo mês

        var result = await _leituraVacinas.ObterVacinasProximoMes(id);
        if (result is null || result.Count == 0)
        {
            throw new NaoEncontrado("Nenhuma vacina encontrada para essa criança");
        }

        var Crianca = await _dbContext.Criancas
            .AsNoTracking().FirstAsync();

        var hoje = DateTime.Now.Month;
        
        

        var enviado = await _email.EnviaEmailParaResponsavel(id, "Lembrete De Vacinas",
              $"Olá Responsável pela criança {Crianca.NomeDaCrianca}, Estamos enviando" +
              $" um email para relembrar que a criança tem vacinas para o dia " +
              $"{Crianca.DataDeNascimentoDaCrianca.Day:D2}/{hoje:D2} , Não se esqueça dessa data, " +
              $"em caso de esquecimento comparecer a unidade de Saúde.");


        if (enviado is false)
        {
            throw new NaoEncontrado("Erro ao enviar o email");
        }
        return new RespostaVacinasInfantis
        {
            Vacinas = _mapeamento.Map<List<RespostaSimplificada>>(result)
        };
    }
}
