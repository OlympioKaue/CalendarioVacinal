using Microsoft.EntityFrameworkCore;
using VacinasInfantis.Comunicacao.Resposta.Enfermagem;
using VacinasInfantis.Domain.Entidades;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Infrastrutura.DataBaseAcesso;

namespace VacinasInfantis.Infrastrutura.Repositorios;

internal class EnfermagemRepositorio : IAdicionarProfissionaisSaude, IProfissionalSaudeServico
{
    private readonly VacinaInfantilDbContext _dbcontext;
    public EnfermagemRepositorio(VacinaInfantilDbContext dbContext)
    {
        _dbcontext = dbContext;
    }

    public async Task AddEnfermagem(Profissionais profissionais)
    {
        await _dbcontext.Profissionais.AddAsync(profissionais);
    }

    public async Task<List<RespostaProfissionaisEnfermagemDTO>> ObterProfissionaisAplicadores()
    {
        var profissionais = await _dbcontext.Profissionais
       .Include(p => p.Vacinas) // Inclui as vacinas aplicadas
       .ThenInclude(vc => vc.Crianca)  // Inclui as crianças vacinadas
       .Where(p => p.Vacinas.Any()) // Retorna apenas profissionais que aplicaram vacinas
       .AsNoTracking()
       .ToListAsync();


        return profissionais.Select(p => new RespostaProfissionaisEnfermagemDTO
        {
            Id =p.Id,
            NomeProfissional = p.NomeProfissional,
            RegistroProfissional = p.RegistroProfissional,
            UnidadeSaude = p.UnidadeSaude,
            CriancaVacinada = p.Vacinas.Where(v => v.Crianca != null)
                .Select(v => new CriancaVacinadaProfissional
                {
                    NomeDaCrianca = v.Crianca!.NomeDaCrianca,
                })
                .DistinctBy(c => c.NomeDaCrianca) // Evita Duplicação
                .ToList()

        }).ToList();
    }
}



