using Microsoft.AspNetCore.Mvc;

namespace VuzixApp.API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class SettingsController : ControllerBase
	{
		private readonly ILogger<SettingsController> _logger;

		public SettingsController(ILogger<SettingsController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IActionResult TestConnection()
		{
			_logger.LogInformation("Test connection from {Host}.", Request.Host.Host);
			return Ok();
		}
	}
}
