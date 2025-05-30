using System.ComponentModel.DataAnnotations;

namespace BancoCem.Models.Requests
{
    public class TransferenceRequest
    {
        [Required(ErrorMessage = "Valor da transferencia é obrigatorio.")]
        public decimal Amount { get; set; } = 0;

        [Required(ErrorMessage = "senderID é obrigatorio.")]
        public int SenderId { get; set; }

        [Required(ErrorMessage = "recipientId é obrigatorio.")]
        public int RecipientId { get; set; }
    }
}
