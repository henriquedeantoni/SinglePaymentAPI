using Sprache;

namespace SinglePaymentAPI.Services.Wallets;

public interface IWalletServices
{
    Task<Result<bool>> ExecuteAsync(WalletRequest request);
}
