using FluentValidation;
using VacinasInfantis.Comunicacao.Requisicao.Enfermagem;

namespace VacinasInfantis.Aplicacao.UseCase.Enfermagem.Validacoes;

public class ValidarRegistrosDeEnfermagem : AbstractValidator<RegistroProfissionaisSaude>
{
    public ValidarRegistrosDeEnfermagem()
    {
        RuleFor(enfermagem => enfermagem.Nome)
            .NotEmpty()
            .WithMessage("O nome do enfermeiro é obrigatório")
            .Length(7, 50)
            .WithMessage("O nome do enfermeiro deve ter entre 7 e 50 caracteres.");

      
        RuleFor(enfermagem => enfermagem.Coren)
           .NotEmpty()
           .WithMessage("O registro é obrigatório")
            .Length(6)
           .WithMessage("O registro deve ter exatamente 7 dígitos.");
           

       RuleFor(enfermagem => enfermagem.UnidadeSaude)
            .NotEmpty()
            .WithMessage("A unidade de saúde é obrigatória")
            .Length(7, 50)
            .WithMessage("A unidade de saúde deve ter entre 7 e 50 caracteres.");

    }

}
