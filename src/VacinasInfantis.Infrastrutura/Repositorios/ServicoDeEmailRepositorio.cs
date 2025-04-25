    using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using VacinasInfantis.Domain.Entidades;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;
using VacinasInfantis.Infrastrutura.DataBaseAcesso;
using VacinasInfantis.Infrastrutura.MensagemHTML;

namespace VacinasInfantis.Infrastrutura.Repositorios;

internal class ServicoDeEmailRepositorio : IServicoDeEmailRepositorio
{
    private readonly VacinaInfantilDbContext _dbcontext;
    private readonly ConfiguracaoEmailRepositorio _config;

    public ServicoDeEmailRepositorio(VacinaInfantilDbContext dbcontext, IOptions<ConfiguracaoEmailRepositorio> config)
    {
        _dbcontext = dbcontext;
        _config = config.Value;

    }

    public async Task ExecutarNotificacao(int id)
    {

        var Crianca = await _dbcontext.Criancas
            .AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);
        if (Crianca == null)
        {
            throw new NaoEncontrado("Nenhuma criança encontrada com esse ID");
        }


        var mesHoje = DateTime.Now.Month;
        var mes = (mesHoje + 1);

       await EnviarLembrete(Crianca, mes);

     
    }


    public async Task<bool> EnviaEmailParaResponsavel(int criancaId, string assunto, string corpo)
    {
        var crianca = await _dbcontext.Criancas.AsNoTracking().FirstOrDefaultAsync(v => v.Id == criancaId);
        if (crianca == null || string.IsNullOrEmpty(crianca.EmailResponsavel))
        {
           throw new NaoEncontrado("Nenhuma criança encontrada com esse ID ou email não encontrado");
        }
        return await EnviarEmailAsync(crianca.EmailResponsavel, assunto, corpo);
    }


    public async Task<bool> EnviarEmailAsync(string email, string assunto, string corpo)
    {

        using var smtpClient = new SmtpClient(_config.SmtpServidor, _config.SmtpPorta)
        {
            Credentials = new NetworkCredential(_config.Remetente, _config.SenhaApp),
            EnableSsl = true
        };

        var mensagem = new MailMessage
        {
            From = new MailAddress(_config.Remetente, "Vacinas Infantis"),
            Subject = assunto,
            Body = corpo,
            IsBodyHtml = true
        };

        mensagem.To.Add(email);


        await smtpClient.SendMailAsync(mensagem);
        return true;
    }

    public async Task EnviarLembrete(Criancas crianca, int mes)
    {
        var assunto = "Lembrete De Vacinas";
        var dataVacina = $"{crianca.DataDeNascimentoDaCrianca.Day:D2}/{mes:D2}";
        var mensagemHtml = MensagemDeVacinaService.GerarMensagemHtml(crianca.NomeDaCrianca, dataVacina);

        if(mensagemHtml == null || dataVacina == null)
        {
            throw new NaoEncontrado("Mensagem HTML não encontrada");
        }

        await EnviaEmailParaResponsavel(crianca.Id, assunto, mensagemHtml);


    }


}
