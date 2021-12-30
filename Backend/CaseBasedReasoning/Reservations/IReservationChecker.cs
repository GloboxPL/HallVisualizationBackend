using Backend.Models;
using System;
using System.Collections.Generic;

namespace Backend.CaseBasedReasoning.Reservations
{
	public interface IReservationChecker
	{
		IEnumerable<Tuple<DateTime, DateTime>> GetFreeTimes(DateTime since, DateTime until);
		bool IsvalidSolution(Reservation reservation);
	}
}
