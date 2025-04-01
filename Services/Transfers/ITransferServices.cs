using SinglePaymentAPI.Models.DTOs;
using SinglePaymentAPI.Models.Requests;
using SinglePaymentAPI.Models.Responses;

namespace SinglePaymentAPI.Services.Transfers;

public interface ITransferServices
{
    Task<Result<TransferDTO>> ExecuteAsync(TransferRequest request);
}
