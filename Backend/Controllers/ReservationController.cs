using Microsoft.AspNetCore.Mvc;
using VuzixApp.CBR;
using VuzixApp.Domain.Models;
using VuzixApp.Domain.ReservationCBR;
using VuzixApp.Domain.Services;

namespace VuzixApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservationController : ControllerBase
{
	private const string UserId = "61d76a11c90a2bb9a40dae29";

	private readonly ILogger<ReservationController> _logger;
	private readonly IReservationService _reservationService;

	public ReservationController(ILogger<ReservationController> logger, IReservationService reservationService)
	{
		_logger = logger;
		_reservationService = reservationService;
	}

	[HttpGet("test")]
	public IActionResult Test()
	{
		var t = new TimeSpan(0, 5, 0);
		var mock = new DataSourceMock();
		var rule = new ReservationRule(DataSourceMock.Bob, DataSourceMock.Press.FullName);
		CBR<Reservation> cbr = new ReservationCBR(mock, mock, rule, rule.Person, rule.DeviceFullName);
		var res = cbr.GetResult();
		return new JsonResult(res.Select(x => new { Start = x.Start, End = x.End }));
	}

	[HttpGet]
	public Task<Reservation> GetReservation([FromQuery] string id)
	{
		var reservation = _reservationService.GetReservation(id);
		if (reservation == null)
		{
			throw new Exception("Reservation not found");
		}
		return Task.FromResult(reservation);
	}

	[HttpGet("device")]
	public Task<IEnumerable<Reservation>> GetReservationsForDevice([FromQuery] string deviceId, [FromQuery] DateTime? since, [FromQuery] DateTime? until)
	{
		var reservations = _reservationService.GetReservationsForDevice(deviceId, since, until);
		return Task.FromResult(reservations);
	}

	[HttpPost]
	public Task<Reservation> AddReservation([FromForm] string deviceId, [FromForm] DateTime start, [FromForm] DateTime end)
	{
		var reservation = _reservationService.AddReservation(start, end, deviceId, UserId);
		return Task.FromResult(reservation);
	}

	[HttpDelete]
	public Task RemoveReservation([FromForm] string id)
	{
		_reservationService.RemoveReservation(id);
		return Task.CompletedTask;
	}
}