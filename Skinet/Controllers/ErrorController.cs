

using Microsoft.AspNetCore.Mvc;
using Skinet.Errors;

namespace Skinet.Controllers
{
    [Route("errors/{code}")]
    public class ErrorController :BaseApiController
    {
        [HttpGet]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}