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

    public async Task<List<VacinasCriancas>> ObterVacinasCriancas()
    {
        return await _dbContext.VacinasCriancas.AsNoTracking().ToListAsync();
    }
}
