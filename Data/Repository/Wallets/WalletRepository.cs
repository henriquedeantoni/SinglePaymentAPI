using Microsoft.EntityFrameworkCore;
using SinglePaymentAPI.Models;

namespace SinglePaymentAPI.Data.Repository.Wallets;

public class WalletRepository : IWalletRepository
{
    private readonly ApplicationDbContext _context;
    public WalletRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(WalletEntity wallet)
    {
        await _context.AddAsync(wallet);
    }

    public async Task UpdateAsync(WalletEntity wallet)
    {
        _context.Update(wallet);
    }

    public async Task<WalletEntity?> GetBySsnEin(string ssnOrEin, string email)
    {
        return await _context.Wallets.FirstOrDefaultAsync(wallet => 
                            wallet.SSNorEIN.Equals(ssnOrEin) || wallet.Email.Equals(email));
    }

    public async Task<WalletEntity?> GetById(int id)
    {
        return await _context.Wallets.FindAsync(id);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
