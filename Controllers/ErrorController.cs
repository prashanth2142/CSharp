using CoreAPI.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("error")]
        public IActionResult HandleError()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (exceptionFeature != null)
            {
                var exception = exceptionFeature.Error;
                _logger.LogError(exception, "An unhandled exception occurred.");
            }

            return Problem("An internal server error has occurred.");
        }

        [HttpGet]
        public JsonResult DecryptCode(string stringToDecrypt)
        {
            var result = CryptoService.DESDecrypt(stringToDecrypt);
            return new JsonResult(result);
        }
    }

}
