using Microsoft.EntityFrameworkCore.Storage;
using SinglePaymentAPI.Models;

namespace SinglePaymentAPI.Data.Repository.Transfers
{
    public interface ITransferRepository
    {
        Task AddTransaction(TransferEntity transferEntity);
        Task CommitAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
