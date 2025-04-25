using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Domain.Repositorios.Interfaces;

public interface IServicoDeEmailRepositorio
{
    Task<bool> EnviarEmailAsync(string email, string assunto, string corpo);
    Task<bool> EnviaEmailParaResponsavel(int criancaId, string assunto, string corpo);
    Task ExecutarNotificacao(int id);
}
