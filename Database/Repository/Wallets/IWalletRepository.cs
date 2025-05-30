using BancoCem.Models;

namespace BancoCem.Database.Repository.Wallets
{
    public interface IWalletRepository
    {
        Task AddAsync(WalletEntity wallet);
        Task UpdateAsync(WalletEntity wallet);
        Task<WalletEntity?> GetByIdAsync(int id);
        Task<WalletEntity?> GetByEmailAsync(string email);
        Task<WalletEntity?> GetByCPFCNPJAsync(string cpfCnpj);
        Task CommitAsync();
    }
}
