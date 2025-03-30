using SinglePaymentAPI.Models;

namespace SinglePaymentAPI.Data.Repository.Wallets;

public interface IWalletRepository
{
    Task AddAsync(WalletEntity wallet);
    Task UpdateAsync(WalletEntity wallet);
    Task<WalletEntity?> GetBySsnEin(string ssnOrEin, string email);
    Task<WalletEntity?> GetById(int id);
    Task CommitAsync();
}
