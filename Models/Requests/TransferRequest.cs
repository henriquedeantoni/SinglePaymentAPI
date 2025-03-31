using System.ComponentModel.DataAnnotations;

namespace SinglePaymentAPI.Models.Requests;

public class TransferRequest
{
    [Required(ErrorMessage = "Value must be required.")]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "SenderId must be required.")]
    public int SenderId { get; set; }

    [Required(ErrorMessage = "ReceiverId must be required.")]
    public int ReceiverId { get; set; }
}
