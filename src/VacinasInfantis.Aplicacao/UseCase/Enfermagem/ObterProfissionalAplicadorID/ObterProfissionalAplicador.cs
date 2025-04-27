using AutoMapper;
using VacinasInfantis.Comunicacao.Resposta.Enfermagem;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;

namespace VacinasInfantis.Aplicacao.UseCase.Enfermagem.ObterProfissionalAplicadorID;

public class ObterProfissionalAplicador : IObterProfissionalAplicador
{
    private readonly IProfissionalSaudeServico _servico;
    private readonly IMapper _mapper;

    public ObterProfissionalAplicador(IProfissionalSaudeServico servico, IMapper mapper)
    {
        _servico = servico;
        _mapper = mapper;
    }

    public async Task<RepostaDeListaProfissional> ObterProfissionais()
    {
        // Busca todos os profissionais aplicadores
        // Retorne em uma lista todos os profissionais de enfermagem

        var aplicadores = await _servico.ObterProfissionaisDeEnfermagem();
        if (aplicadores is null || aplicadores.Count == 0)
        {
            throw new NaoEncontrado("Profissional não encontrado");
        }

        return new RepostaDeListaProfissional
        {
            Profissional = _mapper.Map<List<RespostaProfissional>>(aplicadores)
        };
    }

    public async Task<RespostaProfissionalAplicadorDTO> ObterProfissionaisDeImunizacao(int id)
    {
        // Busca todos os profissionais aplicadores por ID
        // e filtra pelo id recebido
        // para retornar apenas o profissional específico
        // Mapeia o resultado para o DTO

        var aplicadores = await _servico.ObterProfissionaisAplicadores();
        if (!aplicadores.Any(x => x.Id == id))
        {
            throw new NaoEncontrado("Este profissional não realizou aplicações de vacinas");
        }
            

        var AplicadoresFiltrados = aplicadores.Where(x => x.Id == id).ToList();
      

        return new RespostaProfissionalAplicadorDTO
        {
            Enfermagem = _mapper.Map<List<RespostaProfissionaisEnfermagemDTO>>(AplicadoresFiltrados)
        };
    }
}

