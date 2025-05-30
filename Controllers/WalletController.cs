using BancoCem.Models.Requests;
using BancoCem.Services.Wallets;
using Microsoft.AspNetCore.Mvc;

namespace BancoCem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
       private readonly IWalletServices _walletServices;
        public WalletController(IWalletServices walletServices)
        {
            _walletServices = walletServices;
        }
        [HttpPost("create-wallet")]
        public async Task<IActionResult> CreateWallet([FromBody] WalletRequest request)
        {
            var result = await _walletServices.ExecuteAsync(request);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Created();
        }
    }
}
