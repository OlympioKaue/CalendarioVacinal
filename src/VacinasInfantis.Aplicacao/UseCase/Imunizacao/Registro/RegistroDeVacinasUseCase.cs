using AutoMapper;
using VacinasInfantis.Comunicacao.Requisicao.Vacinas;
using VacinasInfantis.Comunicacao.Resposta.Vacinas;
using VacinasInfantis.Domain.Entidades;
using VacinasInfantis.Domain.Repositorios.Interfaces;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.Registro;

public class RegistroDeVacinasUseCase : IRegistroDeVacinasUseCase
{
     private readonly IVacinasInfantis _adicionar;
    private readonly IMapper _mapeamento;
    private readonly ISalvadorDeDados _salvador;
    public RegistroDeVacinasUseCase(IVacinasInfantis adicionar, IMapper mapeamento, ISalvadorDeDados salvador)
    {
        _adicionar = adicionar; 
        _mapeamento = mapeamento;
        _salvador = salvador;
    }

    public async Task<RespostaRegistroVacinas> Executar(int criancasId, RegistroDeVacinas registroDeVacinas)
    {
        var entity = _mapeamento.Map<Vacinas>(registroDeVacinas);
        entity.CriancasId = criancasId;


        await _adicionar.AddVacinas(entity);

        await _salvador.Commit();


        var vacinaSalva = await _adicionar.BuscarPorId(entity.Id);
        if (vacinaSalva is null)
        {
            throw new Exception("Erro ao salvar a vacina.");
        }
        return _mapeamento.Map<RespostaRegistroVacinas>(vacinaSalva);

    }
}
