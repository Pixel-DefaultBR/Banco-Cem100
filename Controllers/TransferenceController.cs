using BancoCem.Models.Requests;
using BancoCem.Services.Transference;
using Microsoft.AspNetCore.Mvc;

namespace BancoCem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferenceController : ControllerBase
    {
        private readonly ITransferenceServices _transferenceServices;
        public TransferenceController(ITransferenceServices transferenceServices)
        {
            _transferenceServices = transferenceServices;
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferenceRequest request)
        {
            var result = await _transferenceServices.ExecuteAsync(request);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }

    }
}
