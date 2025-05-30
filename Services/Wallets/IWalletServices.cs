using BancoCem.Models.Requests;
using BancoCem.Models.Responses;


namespace BancoCem.Services.Wallets
{
    public interface IWalletServices
    {
        Task<Result<bool>> ExecuteAsync(WalletRequest request);
    }
}
