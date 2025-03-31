using SinglePaymentAPI.Models.DTOs;
using SinglePaymentAPI.Models.Requests;

namespace SinglePaymentAPI.Services.Transfers;

public interface ITransferServices
{
    Task<Results<TransferDTO>> ExecuteAsync(TransferRequest request);
}
