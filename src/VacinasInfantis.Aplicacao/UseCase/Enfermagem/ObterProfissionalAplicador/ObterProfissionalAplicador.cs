using AutoMapper;
using VacinasInfantis.Comunicacao.Resposta.Enfermagem;
using VacinasInfantis.Domain.Repositorios.Interfaces;

namespace VacinasInfantis.Aplicacao.UseCase.Enfermagem.ObterProfissionalAplicador;

public class ObterProfissionalAplicador : IObterProfissionalAplicador
{
    private readonly IProfissionalSaudeServico _servico;
    private readonly IMapper _mapper;

    public ObterProfissionalAplicador(IProfissionalSaudeServico servico, IMapper mapper)
    {
        _servico = servico;
        _mapper = mapper;
    }

    public async Task<RespostaProfissionalAplicadorDTO> ObterProfissionais()
    {
        // Busca todos os profissionais aplicadores
        // Retorne em uma lista todos os profissionais de enfermagem

        var aplicadores = await _servico.ObterProfissionaisDeEnfermagem();

        return new RespostaProfissionalAplicadorDTO
        {
            Enfermagem = _mapper.Map<List<RespostaProfissionaisEnfermagemDTO>>(aplicadores)
        };
    }

    public async Task<RespostaProfissionalAplicadorDTO> ObterProfissionaisDeImunizacao(int id)
    {
        // Busca todos os profissionais aplicadores por ID
        // e filtra pelo id recebido
        // para retornar apenas o profissional específico
        // Mapeia o resultado para o DTO

        var aplicadores = await _servico.ObterProfissionaisAplicadores();
        aplicadores = aplicadores.Where(x => x.Id == id).ToList();

        return new RespostaProfissionalAplicadorDTO
        {
            Enfermagem = _mapper.Map<List<RespostaProfissionaisEnfermagemDTO>>(aplicadores)
        };
    }
}

