using System;

namespace Backend.Models
{
	public class Reservation
	{
		public Guid Id { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public string Person { get; set; }
		public Device Device { get; set; }
		public string Description { get; set; }

		public Reservation(DateTime start, DateTime end, string person, Device device, string description = "")
		{
			Id = Guid.NewGuid();
			Start = start;
			End = end;
			Person = person;
			Device = device;
			Description = description;
		}
	}
}
