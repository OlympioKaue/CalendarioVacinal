using Microsoft.EntityFrameworkCore;
using VacinasInfantis.Domain.Entidades;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Excecao.BaseDaExcecao;
using VacinasInfantis.Infrastrutura.DataBaseAcesso;

namespace VacinasInfantis.Infrastrutura.Repositorios;


internal class TesteDeCriancas : ICriancasRepositorio
{
    private readonly VacinaInfantilDbContext _dbContext;
    public TesteDeCriancas(VacinaInfantilDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddCriancas(Criancas criancas) //ok
    {
        bool criancaExistente = await _dbContext.Criancas
            .AnyAsync(c => c.NomeDaCrianca == criancas.NomeDaCrianca && c.DataDeNascimentoDaCrianca == criancas.DataDeNascimentoDaCrianca &&
            c.NomeDaMae == criancas.NomeDaMae);
        if (criancaExistente is true)
            throw new Excecoes("Criança já cadastrada");



        await _dbContext.Criancas.AddAsync(criancas);

    }

    public void AtualizarCriancas(Criancas criancas) // ok
    {
        _dbContext.Criancas.Update(criancas);
    }


    public async Task<List<Criancas>> BuscarCriancas() //ok
    {
        return await _dbContext.Criancas.AsNoTracking().ToListAsync();
    }

    public async Task<Criancas?> BuscarCriancaPorId(long id) //ok
    {
        return await _dbContext.Criancas.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);
    }

    public void DeletarCrianca(Criancas criancas) //ok
    {
        _dbContext.Criancas.Remove(criancas);
    }



    // ===========================================================================================================================//


    /* SE CASO NÇAO DER ERRO, PODE APAGAR TUDO AQUI EMBAIXO, NAO FAZ PARTE DESSA CLASSE.


    public async Task<List<Vacinas>> ObterVacinasIdade(int id)
    {
        return await _dbContext.Vacinas
              .Where(v => v.CriancasId == id)
              .ToListAsync();
    }

    public async Task<List<CalendarioDeVacinas>> ObterTodasVacinas()
    {
        return await _dbContext.CalendarioDeVacinas.AsNoTracking().ToListAsync();
    }


    public async Task<List<Vacinas>> ObterVacinasAtual(int id)
    {

        var hoje = DateTime.Today;
        bool temVacinasRegistradas = _dbContext.Vacinas.Any(v => v.CriancasId == id);
        if (temVacinasRegistradas is false)
        {
            return new List<Vacinas>();
        }

        var criancas = await _dbContext.Criancas.Where(v => v.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync(v => v.Id == id);
        if (criancas is null)
        {
            return new List<Vacinas>();
        }


        var diaDeNascimento = new DateTime(hoje.Year, hoje.Month, criancas.DataDeNascimentoDaCrianca.Day);
        if (hoje.Day > criancas.DataDeNascimentoDaCrianca.Day || hoje.Day < 30)
        {
            // Idade em meses
            int idadeMeses = ((hoje.Year - criancas.DataDeNascimentoDaCrianca.Year) * 12) + (hoje.Month - criancas.DataDeNascimentoDaCrianca.Month);

            // Vacina Mês Atual
            var vacinaMesAtual = _dbContext.Vacinas.Include(v => v.ProfissionalSaude).Where(v => v.MesAplicacao == idadeMeses).ToList();


            return vacinaMesAtual;
        }


        return new List<Vacinas>();

    }

    public async Task<List<CalendarioDeVacinas>> ObterVacinasProximoMes(int id)
    {

        var hoje = DateTime.Today;

        bool temCriancaRegistrada = _dbContext.Criancas.Any(v => v.Id == id);
        if (temCriancaRegistrada is false)
        {
            return new List<CalendarioDeVacinas>();
        }


        var crianca = await _dbContext.Criancas
            .AsNoTracking()
            .FirstOrDefaultAsync(v => v.Id == id);
        if (crianca is null)
        {
            return new List<CalendarioDeVacinas>();
        }



        var diaDeNascimento = new DateTime(hoje.Year, hoje.Month, crianca.DataDeNascimentoDaCrianca.Day);
        if (hoje.Day >= crianca.DataDeNascimentoDaCrianca.Day)
        {
            diaDeNascimento = diaDeNascimento.AddMonths(1);
        }

        int diasRestantes = (diaDeNascimento - hoje).Days;
        if (diasRestantes >= 1 || diasRestantes <= 31) //Dia 29 de cada mês avise
        {


            //Calcule a idade em meses
            int idadeMeses = ((hoje.Year - crianca.DataDeNascimentoDaCrianca.Year) * 12) + (hoje.Month - crianca.DataDeNascimentoDaCrianca.Month);

            // Vacina Mês Seguinte
            var VacinaMesSeguinte = _dbContext.CalendarioDeVacinas.Where(v => v.MesAplicacao == idadeMeses + 1).ToList();

            return VacinaMesSeguinte;
        }


        return new List<CalendarioDeVacinas>();

    }
    */

}
