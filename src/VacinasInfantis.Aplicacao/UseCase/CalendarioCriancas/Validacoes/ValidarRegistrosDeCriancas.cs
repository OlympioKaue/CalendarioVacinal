using FluentValidation;
using System.Text.RegularExpressions;
using VacinasInfantis.Comunicacao.Requisicao.Criancas;

namespace VacinasInfantis.Aplicacao.UseCase.CalendarioCriancas.Validacoes;

public class ValidarRegistrosDeCriancas : AbstractValidator<InfantilCriancas>
{

    public ValidarRegistrosDeCriancas()
    {
        RuleFor(criancas => criancas.NomeDaCrianca)
            .NotEmpty()
            .WithMessage("O nome da criança é obrigatório.")
            .Length(7, 50)  
            .WithMessage("O nome da criança deve ter entre 7 e 50 caracteres.");


        RuleFor(mae => mae.NomeDaMae)
            .NotEmpty()
            .WithMessage("O nome da mãe é obrigatório.")
            .Length(7, 50)
            .WithMessage("O nome da mãe deve ter entre 7 e 50 caracteres.");



        // O nome do pai é opcional (devido a ausência no registro civil)



        RuleFor(data_nascimento => data_nascimento.DataDeNascimentoDaCrianca)
            .NotEmpty()
            .Must(data => data.Date != DateTime.Today)
            .WithMessage("A data de nascimento da criança não pode ser igual a data atual.")
            // essa pratica evita que o usuario não esqueça de digitar a data de nascimento, se esquecer vai iniciar com a data padrão, gerando erro


            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("A data de nascimento da criança deve ser menor ou igual a data atual.");


        RuleFor(email => email.EmailResponsavel)
            .NotEmpty()
            .WithMessage("O email do responsável é obrigatório.")
            .Must(EmailValido)
            .WithMessage("O email do responsável deve ser válido com dominio permitido");






    }

    private bool EmailValido(string email)
    {
        if (string.IsNullOrEmpty(email))
            return false;

        string padrao = @"^[\w\.\-]+@(?:outlook\.com|gmail\.com|hotmail\.com)$";
       return Regex.IsMatch(email, padrao, RegexOptions.IgnoreCase);
    }
}
