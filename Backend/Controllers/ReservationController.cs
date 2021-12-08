﻿using Backend.CaseBasedReasoning;
using Backend.CaseBasedReasoning.Reservations;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

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
			var t = new System.TimeSpan(0, 5, 0);
			var mock = new DataSourceMock();
			var rule = new ReservationRule(DataSourceMock.Bob, DataSourceMock.Press.FullName);
			CBR<Reservation> cbr = new ReservationCBR(mock, mock, rule, rule.Person, rule.DeviceFullName);
			var res = cbr.GetResult();
			return new JsonResult(res.Select(x => new { Start = x.Start, End = x.End }));
		}
	}
}
