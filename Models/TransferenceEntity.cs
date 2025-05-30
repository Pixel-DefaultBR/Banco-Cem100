using BancoCem.Models;

namespace BancoCem.Models
{
    public class TransferenceEntity
    {
        public Guid Id { get; set; }
        public int SenderId { get; set; }
        public WalletEntity Sender { get; set; }
        public int RecipientId { get; set; }
        public WalletEntity Recipient { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransferDate { get; set; } = DateTime.UtcNow;

        public TransferenceEntity(int senderId, WalletEntity sender,
            int recipientId, WalletEntity recipient, decimal amount)
        {
            Id = Guid.NewGuid();
            SenderId = senderId;
            Sender = sender ?? throw new ArgumentNullException(nameof(sender), "Sender cannot be null.");
            RecipientId = recipientId;
            Recipient = recipient ?? throw new ArgumentNullException(nameof(recipient), "Recipient cannot be null.");
            Amount = amount > 0 ? amount : throw new ArgumentException("Transfer amount must be greater than zero.", nameof(amount));
        }
        private TransferenceEntity() { }
    }
}
