using BancoCem.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace BancoCem.Database.Repository.Transferences
{
    public class TransferenceRepository : ITransferenceRepository
    {
        private readonly AppDbContext _context;
        public TransferenceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TransferenceEntity transference)
        {
            await _context.Transferences.AddAsync(transference);
        }

        public async Task<IDbContextTransaction> BeginTransferAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
