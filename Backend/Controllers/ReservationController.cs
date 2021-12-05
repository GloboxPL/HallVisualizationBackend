using Backend.CBR;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ReservationController : ControllerBase
	{
		private readonly ILogger<ReservationController> _logger;

		public ReservationController(ILogger<ReservationController> logger)
		{
			_logger = logger;
		}

		[HttpGet("test")]
		public IActionResult Test()
		{
			CBRMain cbr = new();
			return new JsonResult(cbr.GetResult());
		}
	}
}
