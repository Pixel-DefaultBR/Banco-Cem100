using BancoCem.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoCem.Database.Repository.Wallets
{
    public class WalletRepository : IWalletRepository
    {
        private readonly AppDbContext _context;

        public WalletRepository(AppDbContext context
            )
        {
            _context = context;
        }

        public async Task AddAsync(WalletEntity wallet)
        {
            await _context.Wallets.AddAsync(wallet);
        }

        public  Task UpdateAsync(WalletEntity wallet)
        {
            _context.Wallets.Update(wallet);
            return Task.CompletedTask;
        }

        public Task<WalletEntity?> GetByCPFCNPJAsync(string cpfCnpj)
        {
            var wallet = _context.Wallets.FirstOrDefaultAsync(w => w.CPFCNPJ == cpfCnpj);
            return wallet;
        }

        public Task<WalletEntity?> GetByEmailAsync(string email)
        {
            var wallet = _context.Wallets.FirstOrDefaultAsync(w => w.Email == email);
            return wallet;
        }

        public Task<WalletEntity?> GetByIdAsync(int id)
        {
            var wallet = _context.Wallets.FirstOrDefaultAsync(w => w.Id == id);
            return wallet;
        }

        public async Task CommitAsync()
        {
           await _context.SaveChangesAsync();
        }

    }
}
