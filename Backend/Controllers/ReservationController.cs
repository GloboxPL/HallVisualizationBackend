using Microsoft.AspNetCore.Mvc;
using VuzixApp.API.DTO;
using VuzixApp.CBR;
using VuzixApp.Domain.Models;
using VuzixApp.Domain.ReservationCBR;
using VuzixApp.Domain.Services;

namespace VuzixApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservationController : ControllerBase
{
    private const string UserId = "xx-user-id-xx";

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
        var t = new System.TimeSpan(0, 5, 0);
        var mock = new DataSourceMock();
        var rule = new ReservationRule(DataSourceMock.Bob, DataSourceMock.Press.FullName);
        CBR<Reservation> cbr = new ReservationCBR(mock, mock, rule, rule.Person, rule.DeviceFullName);
        var res = cbr.GetResult();
        return new JsonResult(res.Select(x => new { Start = x.Start, End = x.End }));
    }

    [HttpPost("add")]
    public Task<Reservation> AddReservation(AddReservationRequest request)
    {
        var reservation = _reservationService.AddReservation(request.Start, request.End, request.DeviceId, UserId);
        return Task.FromResult(reservation);
    }
}