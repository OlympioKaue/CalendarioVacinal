using AutoMapper;
using VacinasInfantis.Comunicacao.Resposta;
using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Aplicacao.AutoMapper;

public class ArquivosMapeados : Profile
{
    public ArquivosMapeados()
    {
        Respostas();
    }

    private void Requisicoes()
    {


    }

    private void Respostas()
    {
        CreateMap<VacinasCriancas, RespostaSimplificada>();
        CreateMap<VacinasCriancas, RespostaVacinas>();
    }

}