using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using webhook.Models;

namespace webhook.Controllers
{
    [ApiController]
    [Route("webhook")]
    public class WebhookController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<WebhookController> _logger;

        public WebhookController(IConfiguration configuration, ILogger<WebhookController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        [HttpPost]
        [Route("receiveMessage")]
        public ActionResult ReceiveMessage([FromBody] object content)
        {
            return Ok(new
            {
                status_code = 200,
                data = content,
                message = "message receive"
            });
        }

        [HttpGet]
        [Route("facebook/verify")]
        public ActionResult VerifyFacebook([FromQuery] FacebookVerifyParams verifyParams)
        {
            string verifyToken = _configuration["FacebookConfig:Webhook:VerifyToken"]!;

            _logger.LogDebug($"verifyToken: {verifyToken}");
            _logger.LogDebug($"FacebookVerifyParams: {JsonSerializer.Serialize(verifyParams)}");

            if (verifyParams.VerifyToken != verifyToken)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            return Ok(verifyParams.Challenge);
        }
    }
}