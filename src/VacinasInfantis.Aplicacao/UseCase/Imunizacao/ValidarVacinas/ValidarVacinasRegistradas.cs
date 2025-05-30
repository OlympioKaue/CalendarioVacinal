﻿using FluentValidation;
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
            .InclusiveBetween(0, 48)
            .WithMessage("O mês de aplicação deve ser entre 0 a 48 meses");


        RuleFor(vacina => vacina.DataAplicacao)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("A data de aplicação não pode ser maior que a data atual");


    }


}

