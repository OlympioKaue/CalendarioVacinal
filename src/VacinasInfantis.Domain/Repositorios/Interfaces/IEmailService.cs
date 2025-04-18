namespace VacinasInfantis.Domain.Repositorios.Interfaces;

public interface IEmailService
{
    Task<bool> EnviarEmailAsync(string email,string assunto, string corpo);
    Task<bool> EnviaEmailParaResponsavel(int criancaId, string assunto, string corpo);
}
