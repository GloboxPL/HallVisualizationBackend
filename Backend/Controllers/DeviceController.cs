using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DeviceController : ControllerBase
	{
		private readonly ILogger<DeviceController> _logger;
		private readonly IDatabaseManager _databaseManager;

		public DeviceController(ILogger<DeviceController> logger, IDatabaseManager databaseManager)
		{
			_logger = logger;
			_databaseManager = databaseManager;
		}

		[HttpGet]
		public IActionResult GetDevice([FromQuery] string id)
		{
			return new JsonResult(_databaseManager.GetDevice(id));
		}

		[HttpGet("all")]
		public IActionResult GetAllDevice()
		{
			return new JsonResult(_databaseManager.GetAllDevices());
		}
	}
}
