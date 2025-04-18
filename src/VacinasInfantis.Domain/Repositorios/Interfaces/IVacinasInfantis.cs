using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Domain.Repositorios.Interfaces;

public interface IVacinasInfantis
{
    Task AddVacinas(Vacinas vacinas);
    Task AddCriancas(Criancas criancas);
    Task<List<Criancas>> BuscarCriancas();
    Task <Profissionais?>BuscarPorId(int id);
}
