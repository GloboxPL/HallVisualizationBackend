using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.CaseBasedReasoning.Reservations
{
	public class ReservationRule
	{
		public DateTime? Since { get; init; }
		public DateTime? Until { get; init; }
		public TimeSpan? Duration { get; init; }
		public string Person { get; }
		public string DeviceFullName { get; }

		public ReservationRule(string person, string deviceFullName)
		{
			Person = person;
			DeviceFullName = deviceFullName;
		}
	}
}
