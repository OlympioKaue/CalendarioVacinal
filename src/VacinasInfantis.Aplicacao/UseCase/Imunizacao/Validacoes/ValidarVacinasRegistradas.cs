using FluentValidation;
using Microsoft.EntityFrameworkCore;
using VacinasInfantis.Comunicacao.Requisicao.Vacinas;
using VacinasInfantis.Infrastrutura.DataBaseAcesso;

namespace VacinasInfantis.Aplicacao.UseCase.Imunizacao.Validacoes;

public class ValidarVacinasRegistradas : AbstractValidator<RegistroDeVacinas>
{


    public ValidarVacinasRegistradas()
    {
        RuleFor(vacina => vacina.NomeDaVacina)
            .NotEmpty()
            .WithMessage("O nome da vacina é obrigatório")
            .Length(2, 100)
            .WithMessage("O nome da vacina deve ter entre 2 a 50 caractere");

        RuleFor(vacina => vacina.DataDeAplicacao)
           
            .Must(vacina => vacina >= 0 || vacina.ToString().Length == 2 || vacina.ToString().Length == 1)
            .WithMessage("O mês de aplicação deve entre igual ou maior que 0 meses, os digitos deve ter entre 1 a 2 caracteres");

        RuleFor(vacina => vacina.DataAplicacao)
            .NotEmpty()
            .WithMessage("A data de aplicação é obrigatória")
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("A data de aplicação não pode ser maior que a data atual");

       // RuleFor(vacina => vacina.ProfissionalSaudeId)
         //   .NotEmpty()
          //  .WithMessage("O profissional de saúde é obrigatório")
          //  .GreaterThan(0)
           // .WithMessage("O Id do profissional de saúde deve ser maior que 0");





    }


}

