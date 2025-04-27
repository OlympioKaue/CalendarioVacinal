using AutoMapper;
using VacinasInfantis.Aplicacao.UseCase.Enfermagem.Validacoes;
using VacinasInfantis.Comunicacao.Requisicao.Enfermagem;
using VacinasInfantis.Comunicacao.Resposta.Enfermagem;
using VacinasInfantis.Domain.Entidades;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;

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

    public async Task<RespostaRegistroEnfermagem> RegistrarProfissionaisDaEnfermagem(RegistroProfissionaisSaude registro)
    {
        // Valide o registros de entrada

        // Mapeia o registro de entrada para a entidade Profissionais
        // Adicione o profissional de saúde ao banco de dados
        // e salve as alterações
        // Retorna a resposta mapeada

        Validate(registro);

        var result = _mapeamento.Map<Profissionais>(registro);

        await _adicionar.AddEnfermagem(result);

        await _salvador.Commit();

        return _mapeamento.Map<RespostaRegistroEnfermagem>(result);
        
    }

    private void Validate(RegistroProfissionaisSaude registro)
    {
        var validacoes = new ValidarRegistrosDeEnfermagem();
        var resultado = validacoes.Validate(registro);

        if (resultado.IsValid is false)
        {
            var listaDeErro = resultado.Errors
                .Select(x => x.ErrorMessage)
                .ToList();

            throw new Excecoes(listaDeErro);
        }
    }
}
