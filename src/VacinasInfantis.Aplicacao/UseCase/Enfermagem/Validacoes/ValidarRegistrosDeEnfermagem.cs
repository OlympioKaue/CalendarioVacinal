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
            .Length(2, 50)
            .WithMessage("O nome do enfermeiro deve ter entre 2 e 50 caracteres.");

        RuleFor(enfermagem => enfermagem.Coren.ToString().Length)
            .NotEmpty()
            .WithMessage("O registro é obrigatório")
          .Must(coren => coren >= 0 && coren.ToString().Length == 7) // tava (&&), se não der coloca (||)
            .WithMessage("O registro deve ter exatamente 7 dígitos.");

       RuleFor(enfermagem => enfermagem.UnidadeSaude)
            .NotEmpty()
            .WithMessage("A unidade de saúde é obrigatória")
            .Length(2, 50)
            .WithMessage("A unidade de saúde deve ter entre 2 e 50 caracteres.");

    }

}
