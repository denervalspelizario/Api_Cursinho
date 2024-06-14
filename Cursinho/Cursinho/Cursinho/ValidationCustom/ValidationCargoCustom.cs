using System.ComponentModel.DataAnnotations;

namespace Cursinho.ValidationCustom
{
    // adicionando metodos de validacao do dataAnnotations a classe ValidationCargoCustom
    public class ValidationCargoCustom : ValidationAttribute 
    {
        // atributo estático que contém todos os cargos permitidos
        private static readonly string[] CargosPermitidos =
        {
            "secretaria",
            "professor",
            "zeladoria",
            "gerencia"
        };

        // sobrescrevendo o método ValidationResult
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // validando se parametro value for null e não for de string
            if (value == null || !(value is string))
            {
                return new ValidationResult("O cargo é obrigatório e deve ser uma string.");
            }

            // cargo recebendo value no tipo string e tudo minusculo
            string cargo = value.ToString().ToLower();

            // validando se cargo existe, permitindo e retornando o sucesso da validação
            if (Array.Exists(CargosPermitidos, c => c.Equals(cargo)))
            {
                return ValidationResult.Success;
            }

            // se cargo não existe retorna erro validacao e resposta
            return new ValidationResult($"O cargo '{cargo}' não é válido. Cargos permitidos: {string.Join(", ", CargosPermitidos)}.");
        }

    }
}
