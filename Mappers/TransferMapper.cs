using SinglePaymentAPI.Models;
using SinglePaymentAPI.Models.DTOs;

namespace SinglePaymentAPI.Mappers;

public static class TransferMapper
{
    public static TransferDTO ToTransferDto(this TransferEntity transaction)
    {
        return new TransferDTO(
            transaction.IdTransaction,
            transaction.Sender,
            transaction.Receiver,
            transaction.Value
        );
    }
}

