using Backend.Models;
using System.Collections.Generic;

namespace Backend.CBR
{
	public class Adaptation
	{
		private readonly IEnumerable<Reservation> _similarCases;

		public Adaptation(IEnumerable<Reservation> similarCases)
		{
			_similarCases = similarCases;
		}

		public IEnumerable<Reservation> Adapt()
		{
			List<Reservation> adapted = new();
			foreach (var reservation in _similarCases)
			{
				Adapt(reservation);
				adapted.Add(reservation);
			}
			return adapted;
		}

		private Reservation Adapt(in Reservation reservation)
		{
			return new Reservation(reservation.Start.AddDays(7), reservation.End.AddDays(7), reservation.Person, reservation.Device);
		}
	}
}
