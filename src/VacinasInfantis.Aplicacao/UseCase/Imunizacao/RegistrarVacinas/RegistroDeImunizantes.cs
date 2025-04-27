using AutoMapper;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using VacinasInfantis.Aplicacao.UseCase.Imunizacao.Validacoes;
using VacinasInfantis.Comunicacao.Requisicao.Vacinas;
using VacinasInfantis.Comunicacao.Resposta.Vacinas;
using VacinasInfantis.Domain.Entidades;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;
using VacinasInfantis.Infrastrutura.DataBaseAcesso;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.Registro;

public class RegistroDeImunizantes : IRegistroDeImunizantes
{
    private readonly IVacinasInfantis _adicionar;
    private readonly IMapper _mapeamento;
    private readonly ISalvadorDeDados _salvador;
    public RegistroDeImunizantes(IVacinasInfantis adicionar, IMapper mapeamento, ISalvadorDeDados salvador)
    {
        _adicionar = adicionar;
        _mapeamento = mapeamento;
        _salvador = salvador;

    }

    public async Task<RespostaRegistroVacinas> Executar(int criancasId, RegistroDeVacinas registroDeVacinas)
    {
        // Mapeia o objeto de entrada para a entidade
        // passe o ID da criança para o mapeamento
        // Adicione a vacina ao banco de dados
        // e salve as alterações
        // Verifica se a criança existe, se não existir a crianca e profissional retorne um erro
        // Retorna a vacina salva



        var entity = _mapeamento.Map<Vacinas>(registroDeVacinas);

        var resultadoValidacao = await ObterResultadoValidacao(registroDeVacinas);
        Validate(resultadoValidacao);


        entity.CriancasId = criancasId;
        await _adicionar.AddVacinas(entity);

        await _salvador.Commit();


        return _mapeamento.Map<RespostaRegistroVacinas>(entity);

    }

    private void Validate(ValidationResult registroDeVacinas)
    {



        if (registroDeVacinas.IsValid is false)
        {
            var listaDeErro = registroDeVacinas.Errors
                .Select(v => v.ErrorMessage)
                .ToList();

            throw new Excecoes(listaDeErro);
        }
    }

    private async Task<ValidationResult> ObterResultadoValidacao(RegistroDeVacinas registroDeVacinas)
    {
        var validacoes = new ValidarVacinasRegistradas();
        var resultado = validacoes.Validate(registroDeVacinas);
        var profissional = await _adicionar.BuscarProfissionalDeVacinas(registroDeVacinas.ProfissionalSaudeId);
        
        if (profissional is null)
        {
            resultado.Errors.Add(new ValidationFailure("ProfissionalSaudeId", "O profissional de saúde não existe"));
        }

        return resultado;
    }
}
