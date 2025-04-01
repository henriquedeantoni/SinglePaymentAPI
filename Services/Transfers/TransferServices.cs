using SinglePaymentAPI.Data.Repository.Transfers;
using SinglePaymentAPI.Data.Repository.Wallets;
using SinglePaymentAPI.Models.DTOs;
using SinglePaymentAPI.Models.Requests;
using SinglePaymentAPI.Models.Responses;
using SinglePaymentAPI.Services.Authorizer;

namespace SinglePaymentAPI.Services.Transfers;

public class TransferServices : ITransferServices
{
    private readonly ITransferRepository _transferRepository;
    private readonly IWalletRepository _walletRepository;
    private readonly IAuthorizerServices _authorizerService;
    private readonly INotificationService _notificationService;

    public TransferServices(ITransferRepository transferRepository, IWalletRepository walletRepository, IAuthorizerService authorizerService, INotificationService notificationService)
    {
        _transferRepository = transferRepository;
        _walletRepository = walletRepository;
        _authorizerService = authorizerService;
        _notificationService = notificationService;
    }
    
    public Task<Result<TransferDTO>> ExecuteAsync(TransferRequest request)
    {
        throw new NotImplementedException();
    }
}
