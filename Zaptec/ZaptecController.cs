using Microsoft.AspNetCore.Mvc;

namespace Zaptec
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZaptecController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChargeHistory(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
