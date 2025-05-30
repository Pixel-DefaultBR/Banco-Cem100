using BancoCem.DTOs;
using BancoCem.Models.Requests;
using BancoCem.Models.Responses;

namespace BancoCem.Services.Transference
{
    public interface ITransferenceServices
    {
        Task<Result<TransferenceDTO>> ExecuteAsync(TransferenceRequest request);
    }
}
