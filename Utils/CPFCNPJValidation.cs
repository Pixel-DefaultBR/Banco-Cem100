using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BancoCem.Utils
{
    public class CPFCNPJValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return new ValidationResult(ErrorMessage ?? "O campo é obrigatório.");
            }

            var cpfCnpj = value.ToString()?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(cpfCnpj))
            {
                return new ValidationResult(ErrorMessage ?? "O campo é obrigatório.");
            }

            cpfCnpj = Regex.Replace(cpfCnpj, @"[^\d]", "");

            if (cpfCnpj.Length == 11 && !IsValidCPF(cpfCnpj))
            {
                return new ValidationResult(ErrorMessage ?? "CPF inválido.");
            }

            if (cpfCnpj.Length == 14 && !IsValidCNPJ(cpfCnpj))
            {
                return new ValidationResult(ErrorMessage ?? "CNPJ inválido.");
            }

            if (cpfCnpj.Length != 11 && cpfCnpj.Length != 14)
            {
                return new ValidationResult(ErrorMessage ?? "CPF ou CNPJ inválido.");
            }

            return ValidationResult.Success!;
        }

        private bool IsValidCPF(string cpf)
        {
            if (!Regex.IsMatch(cpf, @"^\d{11}$")) return false;
            if (new string(cpf[0], 11) == cpf) return false;

            var sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (cpf[i] - '0') * (10 - i);

            var remainder = sum % 11;
            var digit1 = (remainder < 2) ? 0 : 11 - remainder;

            if ((cpf[9] - '0') != digit1)
                return false;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (cpf[i] - '0') * (11 - i);

            remainder = sum % 11;
            var digit2 = (remainder < 2) ? 0 : 11 - remainder;

            return (cpf[10] - '0') == digit2;
        }

        private bool IsValidCNPJ(string cnpj)
        {
            if (!Regex.IsMatch(cnpj, @"^\d{14}$")) return false;
            if (new string(cnpj[0], 14) == cnpj) return false;

            int[] multipliers1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multipliers2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var sum = 0;
            for (int i = 0; i < 12; i++)
                sum += (cnpj[i] - '0') * multipliers1[i];

            var remainder = sum % 11;
            var digit1 = (remainder < 2) ? 0 : 11 - remainder;

            if ((cnpj[12] - '0') != digit1)
                return false;

            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += (cnpj[i] - '0') * multipliers2[i];

            remainder = sum % 11;
            var digit2 = (remainder < 2) ? 0 : 11 - remainder;

            return (cnpj[13] - '0') == digit2;
        }
    }
}
