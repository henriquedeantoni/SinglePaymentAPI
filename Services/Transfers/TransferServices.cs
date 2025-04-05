using SinglePaymentAPI.Data.Repository.Transfers;
using SinglePaymentAPI.Data.Repository.Wallets;
using SinglePaymentAPI.Mappers;
using SinglePaymentAPI.Models;
using SinglePaymentAPI.Models.DTOs;
using SinglePaymentAPI.Models.Enum;
using SinglePaymentAPI.Models.Requests;
using SinglePaymentAPI.Models.Responses;
using SinglePaymentAPI.Services.Authorizer;
using SinglePaymentAPI.Services.Notifications;

namespace SinglePaymentAPI.Services.Transfers;

public class TransferServices : ITransferServices
{
    private readonly ITransferRepository _transferRepository;
    private readonly IWalletRepository _walletRepository;
    private readonly IAuthorizerServices _authorizerServices;
    private readonly INotificationServices _notificationServices;

    public TransferServices(ITransferRepository transferRepository, IWalletRepository walletRepository, IAuthorizerServices authorizerServices, INotificationServices notificationServices)
    {
        _transferRepository = transferRepository;
        _walletRepository = walletRepository;
        _authorizerServices = authorizerServices;
        _notificationServices = notificationServices;
    }
    
    public async Task<Result<TransferDTO>> ExecuteAsync(TransferRequest request)
    {
        if (!await _authorizerServices.AuthorizeAsync())
            return Result<TransferDTO>.Failure("not auhtorized");

        var payer = await _walletRepository.GetById(request.SenderId);
        var beneficiary = await _walletRepository.GetById(request.ReceiverId);

        if(payer is null || beneficiary is null)
            return Result<TransferDTO>.Failure("Any wallet has found.");

        if (payer.Balance < request.Value || payer.Balance == 0)
            return Result<TransferDTO>.Failure("Insuficient Balance");

        if (payer.UserType == UserType.BusinessOwner)
            return Result<TransferDTO>.Failure("Business Owner cannot make any transfer");

        payer.DebitToBalance(request.Value);
        beneficiary.CreditToBalance(request.Value);

        var transfer = new TransferEntity(payer.Id, beneficiary.Id, request.Value);

        //rollback
        using (var transferScope = await _transferRepository.BeginTransactionAsync())
        {
            try
            {
                var updateTasks = new List<Task>
                {
                    _walletRepository.UpdateAsync(payer),
                    _walletRepository.UpdateAsync(beneficiary),
                    _transferRepository.AddTransaction(transfer)
                };

                await Task.WhenAll(updateTasks);

                //Persisting data
                await _walletRepository.CommitAsync();
                await _transferRepository.CommitAsync();

                await transferScope.CommitAsync();
            }
            catch (Exception ex)
            {
                await transferScope.RollbackAsync();
                return Result<TransferDTO>.Failure("Error while processing the transfer: " + ex.Message);
            }

            await _notificationServices.SendNotification();
            return Result<TransferDTO>.Success(transfer.ToTransferDto());
        }
    }
}
