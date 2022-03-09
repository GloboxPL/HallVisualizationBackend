using Microsoft.AspNetCore.Mvc;
using VuzixApp.Domain.Models;
using VuzixApp.Domain.Services;

namespace VuzixApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DevicesController : ControllerBase
{
	private readonly ILogger<DevicesController> _logger;
	private readonly IDeviceService _deviceService;

	public DevicesController(ILogger<DevicesController> logger, IDeviceService deviceService)
	{
		_logger = logger;
		_deviceService = deviceService;
	}

	[HttpGet]
	public Task<Device> GetDevice([FromQuery] string id)
	{
		var device = _deviceService.GetDevice(id);
		if (device == null)
		{
			throw new Exception("Device not found");
		}
		return Task.FromResult(device);
	}

	[HttpGet("all")]
	public Task<IEnumerable<Device>> GetAllDevice()
	{
		var devices = _deviceService.GetAllDevices();
		return Task.FromResult(devices);
	}

	[HttpPut("qr-code")]
	public Task<FileContentResult> GetDeviceQrCode([FromForm] string id)
	{
		var qrCode = _deviceService.GenerateQrCode(id);

		return Task.FromResult(File(qrCode, "image/png", $"{id}.png"));
	}
}