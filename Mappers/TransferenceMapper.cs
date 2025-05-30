using BancoCem.DTOs;
using BancoCem.Models;

namespace BancoCem.Mappers
{
    public static class TransferenceMapper
    {
        public static TransferenceDTO TransferenceDTO(this TransferenceEntity transference)
        {
            return new TransferenceDTO(
                transference.Id,
                transference.Sender,
                transference.Recipient,
                transference.Amount,
                transference.TransferDate
                );
        }
    }
}
