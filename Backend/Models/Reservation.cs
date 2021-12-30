using System;

namespace Backend.Models
{
	public class Reservation
	{
		public Guid Id { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public TimeSpan Duration => End - Start;
		public string Person { get; set; }
		public Device Device { get; set; }
		public string Description { get; set; }

		public Reservation(DateTime start, DateTime end, string person, Device device, string description = "")
		{
			if (start >= end) throw new ArgumentException("Start date should be earlier than end date");
			Id = Guid.NewGuid();
			Start = start;
			End = end;
			Person = person;
			Device = device;
			Description = description;
		}
	}
}
