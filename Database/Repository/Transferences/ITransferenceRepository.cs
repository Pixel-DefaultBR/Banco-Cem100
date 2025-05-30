using BancoCem.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace BancoCem.Database.Repository.Transferences
{
    public interface ITransferenceRepository
    {
        Task AddAsync(TransferenceEntity transference);
        Task<IDbContextTransaction> BeginTransferAsync();
        Task CommitAsync();
    }
}
