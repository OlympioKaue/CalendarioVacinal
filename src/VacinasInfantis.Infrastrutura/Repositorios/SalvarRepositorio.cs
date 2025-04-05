using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Infrastrutura.DataBaseAcesso;

namespace VacinasInfantis.Infrastrutura.Repositorios;

internal class SalvarRepositorio : ISalvadorDeDados
{
    private readonly VacinaInfantilDbContext _dbContext;

    public SalvarRepositorio(VacinaInfantilDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}
