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

    public async Task<ProfissionalAplicadorDto> ObterProfissionaisAplicadores(int id)
    {
        var aplicadores = await _servico.ObterProfissionaisAplicadores();
        aplicadores = aplicadores.Where(x => x.Id == id).ToList();

        return new ProfissionalAplicadorDto
        {
            Enfermagem = _mapper.Map<List<RespostaProfissionaisEnfermagemDTO>>(aplicadores)
        };
    }
}

