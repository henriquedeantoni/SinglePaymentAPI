using SinglePaymentAPI.Models.Enum;
using SinglePaymentAPI.Utils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SinglePaymentAPI.Models.Requests;

public class WalletRequest
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The SSN or EIN number are required!")]
    [SsnOrEinValidationAttribute(ErrorMessage = "The SSN or EIN informed are invalid")]
    public string SSNorEIN { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Email must be valid")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password  { get; set; }

    [Required(ErrorMessage = "User tipe is required")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserType UserType { get; set; }

    [Required(ErrorMessage = "The Count Balance is required.")]
    public decimal Balance { get; set; }

}
