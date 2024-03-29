﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VuzixApp.API.DTOs.Responses;
using VuzixApp.CBR;
using VuzixApp.Models;
using VuzixApp.Domain.Services;
using VuzixApp.ReservationDatesPrediction;

namespace VuzixApp.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ReservationController : ControllerBase
{
	private readonly ILogger<ReservationController> _logger;
	private readonly IReservationService _reservationService;
	private readonly IUserAuthorization _userAuthorization;
	private readonly IRetrieve<Reservation> _retrive;

	public ReservationController(
		ILogger<ReservationController> logger,
		IReservationService reservationService,
		IUserAuthorization userAuthorization,
		IRetrieve<Reservation> retrive)
	{
		_logger = logger;
		_reservationService = reservationService;
		_userAuthorization = userAuthorization;
		_retrive = retrive;
	}

	[HttpGet("propose")]
	public Task<IEnumerable<Reservation>> ProposeBookingDates([FromQuery] string deviceId)
	{
		var user = _userAuthorization.GetUserFromHttpRequest();
		var dataR = new DataR(user.Id, deviceId);
		var reuse = new Reuse(user.Id, deviceId, _reservationService.GetReservationsForDevice(deviceId));
		CBR<Reservation, DataR> cbr = new ReservationCBR(_retrive, reuse);
		var res = cbr.GetResult(dataR);
		return Task.FromResult(res);
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
	public Task<IEnumerable<ReservationWithUser>> GetReservationsForDevice([FromQuery] string deviceId, [FromQuery] DateTime? since, [FromQuery] DateTime? until)
	{
		var reservations = _reservationService.GetReservationsForDevice(deviceId, since, until);
		var users = _reservationService.GetUsersForReservations(reservations);
		var reservationsWithUsers = reservations.Select(r => new ReservationWithUser(r, users.First(u => u.Id == r.UserId)));

		return Task.FromResult(reservationsWithUsers);
	}

	[HttpPost]
	public Task<Reservation> AddReservation([FromForm] string deviceId, [FromForm] DateTime start, [FromForm] DateTime end)
	{
		var reservation = _reservationService.AddReservation(start, end, deviceId);
		return Task.FromResult(reservation);
	}

	[HttpDelete]
	public Task RemoveReservation([FromForm] string id)
	{
		_reservationService.RemoveReservation(id);
		return Task.CompletedTask;
	}
}