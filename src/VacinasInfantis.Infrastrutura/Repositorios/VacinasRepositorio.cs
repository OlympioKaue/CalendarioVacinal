using Microsoft.EntityFrameworkCore;
using VacinasInfantis.Domain.Entidades;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Infrastrutura.DataBaseAcesso;

namespace VacinasInfantis.Infrastrutura.Repositorios;

internal class VacinasRepositorio : ILeituraVacinasRepositorio
{
    private readonly VacinaInfantilDbContext _dbContext;

    public VacinasRepositorio(VacinaInfantilDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<VacinasCriancas>> ObterVacinasAtrasadas(long idade)
    {
        return await _dbContext.VacinasCriancas.AsNoTracking().Where(user => user.MesAplicacao <= idade).ToListAsync();
    }

    public async Task<List<VacinasCriancas>> ObterVacinasCriancas()
    {
        return await _dbContext.VacinasCriancas.AsNoTracking().ToListAsync();
    }

    public async Task<VacinasCriancas?> ObterVacinasIdade(long idade)
    {
        return await _dbContext.VacinasCriancas.AsNoTracking().FirstOrDefaultAsync(user => user.MesAplicacao == idade);
    }
}
