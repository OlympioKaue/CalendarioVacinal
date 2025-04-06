using FluentValidation;
using VacinasInfantis.Comunicacao.Requisicao.Criancas;

namespace VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.Validacoes;

public class ValidarRegistrosDeCriancas : AbstractValidator<RegistrarCriancas>
{

    public ValidarRegistrosDeCriancas()
    {
        RuleFor(criancas => criancas.NomeDaCrianca)
            .NotEmpty()
            .WithMessage("O nome da criança é obrigatório.")
            .Length(2, 50)  
            .WithMessage("O nome da criança deve ter entre 2 e 50 caracteres.");
        RuleFor(mae => mae.NomeDaMae)
            .NotEmpty()
            .WithMessage("O nome da mãe é obrigatório.")
            .Length(2, 50)
            .WithMessage("O nome da mãe deve ter entre 2 e 50 caracteres.");

        // O nome do pai é opcional (devido a ausência no registro civil)

        RuleFor(data_nascimento => data_nascimento.DataDeNascimentoDaCrianca)
            .NotEmpty()
            .Must(data => data.Date != DateTime.Today)
            .WithMessage("A data de nascimento da criança não pode ser igual a data atual.")
            // essa pratica evita que o usuario não esqueça de digitar a data de nascimento, se esquecer vai iniciar com a data padrão, gerando erro


            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("A data de nascimento da criança deve ser menor ou igual a data atual.");

        
          

            
    }
}
