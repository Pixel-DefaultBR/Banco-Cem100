using BancoCem.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BancoCem.Utils;

namespace BancoCem.Models.Requests
{
    public class WalletRequest
    {
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo 'CPF' ou 'CNPJ' é obrigatório.")]
        [CPFCNPJValidation(ErrorMessage = "CPF / CNPJ invalido")]
        public string CPFCNPJ { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado não é válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo de usuario é obrigatorio.")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserType UserType { get; set; } = UserType.User;

        [Required(ErrorMessage = "O saldo em conta é obrigatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "O saldo em conta deve ser um valor positivo.")]
        public decimal AccountBalance { get; set; } = 0;
    }
}
