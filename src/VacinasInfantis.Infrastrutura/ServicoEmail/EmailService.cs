using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;
using VacinasInfantis.Infrastrutura.DataBaseAcesso;

namespace VacinasInfantis.Infrastrutura.ServicoEmail;

internal class EmailService : IEmailService
{
    private readonly ConfiguracaoEmail _config;
    private readonly VacinaInfantilDbContext _dbcontext;

    public EmailService(IOptions<ConfiguracaoEmail> config, VacinaInfantilDbContext dbContext)
    {
        _config = config.Value;
        _dbcontext = dbContext;
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


    public async Task<bool> EnviaEmailParaResponsavel(int criancaId, string assunto, string corpo)
    {
        var crianca = await _dbcontext.Criancas.AsNoTracking().FirstOrDefaultAsync(v => v.Id == criancaId);
        if (crianca == null || string.IsNullOrEmpty(crianca.EmailResponsavel))
        {
            return false;
        }
        return await EnviarEmailAsync(crianca.EmailResponsavel, assunto, corpo);
    }
}




