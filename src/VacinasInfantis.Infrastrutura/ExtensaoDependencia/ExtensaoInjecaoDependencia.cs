using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VacinasInfantis.Domain.Repositorios.Interfaces;
using VacinasInfantis.Infrastrutura.DataBaseAcesso;
using VacinasInfantis.Infrastrutura.Repositorios;

namespace VacinasInfantis.Infrastrutura.ExtensaoDependencia;

public static class ExtensaoInjecaoDependencia
{
    public static void AdicionarRepositorios(this IServiceCollection services, IConfiguration configuracao)
    {
       

        AdicionarInjecaoDependencia(services);

        AdicionarConexaoBancoDados(services, configuracao);

      


    }



    private static void AdicionarInjecaoDependencia(this IServiceCollection services)
    {
        services.AddScoped<ILeituraVacinasRepositorio, VacinasRepositorio>();
        services.AddScoped<IVacinasInfantis, VacinasRepositorio>();
        services.AddScoped<ISalvadorDeDados, SalvarRepositorio>();
        services.AddScoped<IAdicionarProfissionaisSaude, EnfermagemRepositorio>();
        services.AddScoped<IProfissionalSaudeServico, EnfermagemRepositorio>();
      
     

       

    }



    private static void AdicionarConexaoBancoDados(this IServiceCollection services, IConfiguration configuration)
    {
        var conexao = configuration.GetConnectionString("DefaultConnection");
        var versaoMySql = new MySqlServerVersion(new Version(8, 0, 41));


        services.AddDbContext<VacinaInfantilDbContext>(vacina =>
         vacina.UseMySql(conexao, versaoMySql, vacina => vacina.MigrationsAssembly("VacinasInfantis.API")))
        ;

       


    }



}
