using Microsoft.AspNetCore.Mvc;
using VuzixApp.Domain.Models;
using VuzixApp.Domain.Services;

namespace VuzixApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DeviceController : ControllerBase
{
	private readonly ILogger<DeviceController> _logger;
	private readonly IDeviceService _deviceService;

	public DeviceController(ILogger<DeviceController> logger, IDeviceService deviceService)
	{
		_logger = logger;
		_deviceService = deviceService;
	}

	[HttpGet]
	public Task<Device> GetDevice([FromQuery] string id)
	{
		var device = _deviceService.GetDevice(id);
		return Task.FromResult(device);
	}

	[HttpGet("all")]
	public Task<IEnumerable<Device>> GetAllDevice()
	{
		var devices = _deviceService.GetAllDevices();
		return Task.FromResult(devices);
	}
}