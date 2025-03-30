using SinglePaymentAPI.Data.Repository.Wallets;
using SinglePaymentAPI.Models;
using SinglePaymentAPI.Models.Requests;
using SinglePaymentAPI.Models.Responses;

namespace SinglePaymentAPI.Services.Wallets;

public class WalletServices : IWalletServices
{
    private readonly IWalletRepository _repository;

    public WalletServices(IWalletRepository repository)
    {
        _repository = repository;   
    }
    public async Task<Result<bool>> ExecuteAsync(WalletRequest request)
    {
        var _walletsExists = await _repository.GetBySsnEin(request.SSNorEIN, request.Email);

        if (_walletsExists is not null)
        {
            return Result<bool>.Failure("Wallet already exists");
        }

        var wallet = new WalletEntity(
            request.Name,
            request.SSNorEIN,
            request.Email,
            request.Password,
            request.Balance,
            request.UserType
            );

        await _repository.AddAsync( wallet );
        await _repository.CommitAsync();

        return Result<bool>.Success( true );
    }
}
