using VacinasInfantis.Comunicacao.Resposta.Enfermagem;

namespace VacinasInfantis.Aplicacao.UseCase.Enfermagem.ObterProfissionalAplicadorID;

public interface IObterProfissionalAplicador
{
    public Task<RespostaProfissionalAplicadorDTO> ObterProfissionaisDeImunizacao(int id);
   public Task<ApenasTestelista> ObterProfissionais();
    
}
