using Microsoft.EntityFrameworkCore.Storage;
using SinglePaymentAPI.Models;

namespace SinglePaymentAPI.Data.Repository.Transfers
{
    public class TransferRepository : ITransferRepository
    {
        private readonly ApplicationDbContext _context;

        public TransferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddTransaction(TransferEntity transferEntity)
        {
            await _context.Transfers.AddAsync(transferEntity);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
