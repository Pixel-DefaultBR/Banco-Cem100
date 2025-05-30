using BancoCem.Models;

namespace BancoCem.DTOs
{
    public record TransferenceDTO(Guid IdTransference, WalletEntity Sender,
        WalletEntity Recipient, decimal Amount, DateTime TransferDate){}
}
