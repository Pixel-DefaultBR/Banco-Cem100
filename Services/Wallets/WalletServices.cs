using BancoCem.Database.Repository.Wallets;
using BancoCem.Models;
using BancoCem.Models.Requests;
using BancoCem.Models.Responses;

namespace BancoCem.Services.Wallets
{
    public class WalletServices : IWalletServices
    {
        private readonly IWalletRepository _walletRepository;

        public WalletServices(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<Result<bool>> ExecuteAsync(WalletRequest request)
        {
            var walletExists = await _walletRepository.GetByCPFCNPJAsync(request.CPFCNPJ);

            if (walletExists is not null)
            {
                return Result<bool>.Failure("Carteira já existe");
            }

            var wallet = new WalletEntity(
                request.FullName,
                request.CPFCNPJ,
                request.Email,
                request.Password,
                request.UserType,
                request.AccountBalance);

            await _walletRepository.AddAsync(wallet);
            await _walletRepository.CommitAsync();

            return Result<bool>.Success(true);
        }
    }
}
