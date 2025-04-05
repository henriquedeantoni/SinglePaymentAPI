﻿using Microsoft.AspNetCore.Mvc;
using SinglePaymentAPI.Services.Transfers;
using System.Transactions;

namespace SinglePaymentAPI.Controllers;

[ApiController]
[Route("[transfer]")]
public class TransferController : ControllerBase
{
    private readonly ITransferServices _transferServices;

    public TransferController(ITransferServices transferServices)
    {
        _transferServices = transferServices;
    }

    [HttpPost]
    public async Task<IActionResult> PostUser(TransactionRequest request)
    {
        var result = await _transferServices.ExecuteAsync(request);
        if(!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);        
    }
}
