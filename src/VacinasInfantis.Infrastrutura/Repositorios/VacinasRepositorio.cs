using Microsoft.EntityFrameworkCore;
using VacinasInfantis.Domain.Entidades;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;
using VacinasInfantis.Infrastrutura.DataBaseAcesso;

namespace VacinasInfantis.Infrastrutura.Repositorios;

internal class VacinasRepositorio : ILeituraVacinasRepositorio, IVacinasInfantis
{
    private readonly VacinaInfantilDbContext _dbContext;

    public VacinasRepositorio(VacinaInfantilDbContext dbContext)
    {
        _dbContext = dbContext;
    }



    public async Task AddVacinas(Vacinas vacinas)
    {
        
        var criancaExiste = await _dbContext.Criancas.AnyAsync(crianca => crianca.Id == vacinas.CriancasId);

        if (criancaExiste is false)
        {
            throw new NaoEncontrado("A criança não foi encontrada");
        }


        var vacinaCrianca = new Vacinas
        {
            CriancasId = vacinas.CriancasId,
            NomeDaVacina = vacinas.NomeDaVacina,
            MesAplicacao = vacinas.MesAplicacao,
            ProfissionalSaudeId = vacinas.ProfissionalSaudeId,
            DataAplicacao = vacinas.DataAplicacao
        };

        await _dbContext.Vacinas.AddAsync(vacinaCrianca);
    }

    public async Task<List<Vacinas>> ObterVacinasIdade(int id)
    {
        return await _dbContext.Vacinas
              .Where(v => v.CriancasId == id)
              .ToListAsync();
    }

    public async Task<List<Vacinas>> ObterTodasVacinas()
    {
        return await _dbContext.Vacinas.AsNoTracking().ToListAsync();
    }


    public Task<List<Vacinas>> ObterVacinasAtual(int id)
    {

        var hoje = DateTime.Today;
        bool temVacinasRegistradas = _dbContext.Vacinas.Any(v => v.CriancasId == id);
        if (temVacinasRegistradas is false)
        {
            return Task.FromResult(new List<Vacinas>());
        }




        var criancas = _dbContext.Criancas.Where(v => v.Id == id).AsNoTracking().ToList();
        var vacinasProximas = new List<Vacinas>();


        foreach (var obj in criancas)
        {
            int idadeMeses = ((hoje.Year - obj.DataDeNascimentoDaCrianca.Year) * 12) + (hoje.Month - obj.DataDeNascimentoDaCrianca.Month);

            // Vacina Mês Atual
            var vacinaMesAtual = _dbContext.Vacinas.Include(v => v.ProfissionalSaude).Where(v => v.MesAplicacao == idadeMeses).ToList();
           

            vacinasProximas.AddRange(vacinaMesAtual);




        }




        return Task.FromResult(vacinasProximas);

    }

    public Task<List<Vacinas>> ObterVacinasProximoMes(int id)
    {

        var hoje = DateTime.Today;

        bool temVacinasRegistradas = _dbContext.Vacinas.Any(v => v.CriancasId == id);
        if(temVacinasRegistradas is false)
        {
            return Task.FromResult(new List<Vacinas>());
        }


        var criancas = _dbContext.Criancas.Where(v => v.Id == id).AsNoTracking().ToList();
        var vacinasProximas = new List<Vacinas>();

        foreach (var obj in criancas)
        {
            int idadeMeses = ((hoje.Year - obj.DataDeNascimentoDaCrianca.Year) * 12) + (hoje.Month - obj.DataDeNascimentoDaCrianca.Month);

            // Vacina Mês Seguinte
            var VacinaMesSeguinte = _dbContext.Vacinas.Include(v => v.ProfissionalSaude).Where(v => v.MesAplicacao == idadeMeses + 1).ToList();

            vacinasProximas.AddRange(VacinaMesSeguinte);

        }

        return Task.FromResult(vacinasProximas);
    }

    public async Task<Vacinas?> BuscarPorId(int id)
    {
        return await _dbContext.Vacinas.FirstOrDefaultAsync(x => x.ProfissionalSaudeId == id);
    }

    public async Task AddCriancas(Criancas criancas)
    {
        await _dbContext.Criancas.AddAsync(criancas);

    }



    public async Task<List<Criancas>> BuscarCriancas()
    {
        return await _dbContext.Criancas.AsNoTracking().ToListAsync();
    }

    
}

