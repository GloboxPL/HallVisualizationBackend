using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VuzixApp.Domain.Models;
using VuzixApp.Domain.Services;

namespace VuzixApp.API.Controllers;

[Authorize]
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

	[HttpPost]
	public Task<Device> UpdateDevice(
		[FromQuery] string id,
		[FromForm] int? customId,
		[FromForm] int hallId,
		[FromForm] string? symbol,
		[FromForm] string? shortName,
		[FromForm] string? fullName,
		[FromForm] int? efficiency,
		[FromForm] string? socket,
		[FromForm] int? height,
		[FromForm] DeviceStatus? status,
		[FromForm] string? statusDescription,
		[FromForm] DateTime? technicalExaminationDate,
		[FromForm] string? model3D
		)
	{
		var device = _deviceService.UpdateDevice(id, customId, hallId, symbol, shortName, fullName, efficiency, socket, height, status, statusDescription, technicalExaminationDate, model3D); ;
		return Task.FromResult(device);
	}

	[HttpGet("all")]
	public Task<IEnumerable<string>> GetAllDeviceIds()
	{
		var ids = _deviceService.GetAllDevices().Select(d => d.Id!);
		return Task.FromResult(ids);
	}

	[HttpPut("qr-code")]
	public Task<FileContentResult> GetDeviceQrCode([FromForm] string id)
	{
		var qrCode = _deviceService.GenerateQrCode(id);

		return Task.FromResult(File(qrCode, "image/png", $"{id}.png"));
	}
}