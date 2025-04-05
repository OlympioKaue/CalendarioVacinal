using AutoMapper;
using VacinasInfantis.Comunicacao.Requisicao.Criancas;
using VacinasInfantis.Comunicacao.Requisicao.Enfermagem;
using VacinasInfantis.Comunicacao.Requisicao.Vacinas;
using VacinasInfantis.Comunicacao.Resposta.Criancas;
using VacinasInfantis.Comunicacao.Resposta.Enfermagem;
using VacinasInfantis.Comunicacao.Resposta.Vacinas;
using VacinasInfantis.Domain.Entidades;

namespace VacinasInfantis.Aplicacao.AutoMapper;

public class ArquivosMapeados : Profile
{
    public ArquivosMapeados()
    {
        Requisicoes();
        Respostas();
    }

    private void Requisicoes()
    {
        CreateMap<RegistroVacinal, Criancas>();

        CreateMap<RegistroDeVacinas, Vacinas>()
        .ForMember(dest => dest.NomeDaVacina, opt => opt.MapFrom(src => src.NomeDaVacina))
        .ForMember(dest => dest.MesAplicacao, opt => opt.MapFrom(src => src.DataDeAplicacao));
       

       

        CreateMap<RegistroProfissionaisSaude, Profissionais>()
        .ForMember(dest => dest.NomeProfissional, opt => opt.MapFrom(src => src.Nome))
        .ForMember(dest => dest.RegistroProfissional, opt => opt.MapFrom(src => src.Coren));




    }

    private void Respostas()
    {
        CreateMap<Vacinas, RespostaSimplificada>();
        CreateMap<Vacinas, RespostaDeRegistroVacinas>();

        CreateMap<Vacinas, RespostaRegistroVacinas>()
       .ForMember(dest => dest.NomeDaVacina, opt => opt.MapFrom(src => src.NomeDaVacina))
       .ForMember(dest => dest.DataAplicacao, opt => opt.MapFrom(src => src.MesAplicacao))
       .ForMember(dest => dest.DataAplicacao, opt => opt.MapFrom(src => src.DataAplicacao));

        CreateMap<Criancas, RespostaDeRegistro>();
        CreateMap<Criancas, RespostaSimplificada>();

        CreateMap<Profissionais, RespostaRegistroEnfermagem>();

        CreateMap<Profissionais, RespostaProfissionaisEnfermagemDTO>()
       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
       .ForMember(dest => dest.NomeProfissional, opt => opt.MapFrom(src => src.NomeProfissional))
       .ForMember(dest => dest.RegistroProfissional, opt => opt.MapFrom(src => src.RegistroProfissional))
       .ForMember(dest => dest.UnidadeSaude, opt => opt.MapFrom(src => src.UnidadeSaude));
           
       

        CreateMap<Criancas, CriancasSalvas>();
          


    }
}

