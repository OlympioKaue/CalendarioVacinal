using VacinasInfantis.Comunicacao.Resposta.Enfermagem;

namespace VacinasInfantis.Aplicacao.UseCase.Enfermagem.ObterProfissionalAplicador;

public interface IObterProfissionalAplicador
{
    public Task<RespostaProfissionalAplicadorDTO> ObterProfissionaisDeImunizacao(int id);
   public Task<RespostaProfissionalAplicadorDTO> ObterProfissionais();
    
}
