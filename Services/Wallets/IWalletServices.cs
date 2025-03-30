using SinglePaymentAPI.Models.Requests;
using SinglePaymentAPI.Models.Responses;

namespace SinglePaymentAPI.Services.Wallets;

public interface IWalletServices
{
    Task<Result<bool>> ExecuteAsync(WalletRequest request);
}
