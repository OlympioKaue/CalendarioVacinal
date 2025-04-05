using AutoMapper;
using VacinasInfantis.Comunicacao.Requisicao.Enfermagem;
using VacinasInfantis.Comunicacao.Resposta.Enfermagem;
using VacinasInfantis.Domain.Entidades;
using VacinasInfantis.Domain.Repositorios.Interfaces;

namespace VacinasInfantis.Aplicacao.UseCase.Enfermagem.Registro;

public class RegistroEnfermagemUseCase : IRegistroEnfermagemUseCase
{
    private readonly IAdicionarProfissionaisSaude _adicionar;
    private readonly IMapper _mapeamento;
    private readonly ISalvadorDeDados _salvador;


    public RegistroEnfermagemUseCase(IAdicionarProfissionaisSaude adicionar, IMapper mapemanto, ISalvadorDeDados salvador)
    {
        _adicionar = adicionar;
        _mapeamento = mapemanto;
        _salvador = salvador;
    }

    public async Task<RespostaRegistroEnfermagem> Executar(RegistroProfissionaisSaude registro)
    {
        var result = _mapeamento.Map<Profissionais>(registro);

        await _adicionar.AddEnfermagem(result);

        await _salvador.Commit();

        return _mapeamento.Map<RespostaRegistroEnfermagem>(result);
        
    }
}
