namespace SinglePaymentAPI.Models.DTOs;

public record TransferDTO(Guid IdTransaction, WalletEntity Sender, WalletEntity Receiver, decimal TransferedValue);