using Microsoft.AspNetCore.Mvc;
using SinglePaymentAPI.Models.Requests;
using SinglePaymentAPI.Services.Wallets;

namespace SinglePaymentAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WalletController : ControllerBase
{
    private readonly IWalletServices _walletService;
    public WalletController(IWalletServices walletService)
    {
        _walletService = walletService;
    }

    [HttpPost]
    public async Task<IActionResult> PostWallet(WalletRequest request)
    {
        var result = await _walletService.ExecuteAsync(request);

        if (result.IsSuccess)
            return BadRequest(result);

        return Created();
    }
}
