﻿using VuzixApp.CBR;
using VuzixApp.Domain.Models;

namespace VuzixApp.Domain.ReservationCBR;

public class DataSourceMock : IDataSource<Reservation>, IReservationChecker
{
	public static string Bob = "Bob";

	public static string Alice = "Alice";

	public static Device Zwick = new()
	{
		Id = "605b8f861553126224f50c88",
		CustomId = 10000015,
		HallId = 0,
		Symbol = "10000-15",
		ShortName = "Zwick",
		FullName = "Zwick",
		Efficiency = 100,
		Socket = "Zwick",
		Height = 1
	};

	public static Device Press = new()
	{
		Id = "605b8f861553126224f50c89", //"605b8f861553126224f50c97",
		CustomId = 10000016,
		HallId = 0,
		Symbol = "10000-16",
		ShortName = "Prasa500T",
		FullName = "Prasa500T",
		Efficiency = 100,
		Socket = "Prasy",
		Height = 1
	};

	public static List<Reservation> Reservations = new()
	{
		// new Reservation(new DateTime(2021, 11, 29, 8, 0, 0), new DateTime(2021, 11, 29, 9, 0, 0), Bob, Press),
		// new Reservation(new DateTime(2021, 11, 29, 10, 0, 0), new DateTime(2021, 11, 29, 11, 0, 0), Bob, Zwick),
		// new Reservation(new DateTime(2021, 11, 30, 9, 0, 0), new DateTime(2021, 11, 30, 11, 0, 0), Bob, Zwick),
		// new Reservation(new DateTime(2021, 12, 1, 12, 0, 0), new DateTime(2021, 12, 1, 13, 0, 0), Alice, Press),
		// new Reservation(new DateTime(2021, 12, 1, 15, 0, 0), new DateTime(2021, 12, 1, 17, 0, 0), Alice, Press),
		// new Reservation(new DateTime(2021, 12, 2, 17, 0, 0), new DateTime(2021, 12, 2, 18, 0, 0), Alice, Press),
		// new Reservation(new DateTime(2021, 12, 2, 18, 0, 0), new DateTime(2021, 12, 2, 20, 0, 0), Alice, Zwick),
		// new Reservation(new DateTime(2021, 12, 3, 8, 0, 0), new DateTime(2021, 12, 3, 11, 0, 0), Bob, Press),
		// new Reservation(new DateTime(2021, 12, 8, 11, 0, 0), new DateTime(2021, 12, 8, 12, 30, 0), Alice, Press),
		//
		// new Reservation(new DateTime(2021, 11, 22, 9, 30, 0), new DateTime(2021, 11, 22, 10, 0, 0), Bob, Press),
		// new Reservation(new DateTime(2021, 11, 15, 9, 0, 0), new DateTime(2021, 11, 29, 9, 0, 0), Bob, Press),
		// new Reservation(new DateTime(2021, 11, 16, 10, 0, 0), new DateTime(2021, 11, 16, 11, 0, 0), Bob, Press),
		// new Reservation(new DateTime(2021, 11, 9, 11, 0, 0), new DateTime(2021, 11, 9, 12, 0, 0), Bob, Press),
		// new Reservation(new DateTime(2021, 11, 2, 11, 0, 0), new DateTime(2021, 11, 2, 12, 0, 0), Bob, Press),
		// new Reservation(new DateTime(2021, 12, 14, 10, 30, 0), new DateTime(2021, 12, 14, 11, 15, 0), Alice, Press),
		// new Reservation(new DateTime(2021, 12, 14, 18, 0, 0), new DateTime(2021, 12, 14, 19, 0, 0), Alice, Press),
	};

	public IEnumerable<Reservation> GetFilteredData(params object[] args) //TODO
	{
		var t = Reservations.GroupBy(x => x.UserId);

		IEnumerable<Reservation> result = Reservations;
		if (args[0] is string person)
		{
			result = result.Where(x => x.UserId == person);
		}
		if (args[1] is string deviceFullName)
		{
			// result = result.Where(x => x.Device.FullName == deviceFullName);
		}
		return result;
	}

	public IEnumerable<Tuple<DateTime, DateTime>> GetFreeTimes(DateTime since, DateTime until)
	{

		var reservations = Reservations.Where(x => x.Start < until && x.End > since).OrderBy(x => x.Start);
		if (!reservations.Any())
		{
			return new List<Tuple<DateTime, DateTime>>()
			{
				new (since, until)
			};
		}

		var start = since;
		var freeTimes = new List<Tuple<DateTime, DateTime>>();

		foreach (var reservation in reservations)
		{
			if (reservation.Start > start)
			{
				freeTimes.Add(new(start, reservation.Start));
			}
			start = reservation.End;
		}
		if (start < until)
		{
			freeTimes.Add(new(start, until));
		}
		return freeTimes;
	}

	public bool IsvalidSolution(Reservation reservation)
	{
		throw new NotImplementedException();
	}
}