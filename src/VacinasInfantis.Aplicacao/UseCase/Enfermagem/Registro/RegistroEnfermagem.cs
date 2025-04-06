using AutoMapper;
using VacinasInfantis.Comunicacao.Requisicao.Enfermagem;
using VacinasInfantis.Comunicacao.Resposta.Enfermagem;
using VacinasInfantis.Domain.Entidades;
using VacinasInfantis.Domain.Repositorios.Interfaces;

namespace VacinasInfantis.Aplicacao.UseCase.Enfermagem.Registro;

public class RegistroEnfermagem : IRegistroEnfermagem
{
    private readonly IAdicionarProfissionaisSaude _adicionar;
    private readonly IMapper _mapeamento;
    private readonly ISalvadorDeDados _salvador;


    public RegistroEnfermagem(IAdicionarProfissionaisSaude adicionar, IMapper mapemanto, ISalvadorDeDados salvador)
    {
        _adicionar = adicionar;
        _mapeamento = mapemanto;
        _salvador = salvador;
    }

    public async Task<RespostaRegistroEnfermagem> Executar(RegistroProfissionaisSaude registro)
    {
        // Mapeia o registro de entrada para a entidade Profissionais
        // Adicione o profissional de saúde ao banco de dados
        // e salve as alterações
        // Retorna a resposta mapeada

        var result = _mapeamento.Map<Profissionais>(registro);

        await _adicionar.AddEnfermagem(result);

        await _salvador.Commit();

        return _mapeamento.Map<RespostaRegistroEnfermagem>(result);
        
    }
}
