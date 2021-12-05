using Backend.CBR;
using Backend.Models;
using System;
using System.Collections.Generic;

namespace Backend.Mock
{
	public class CBRMock : ICBRDataSource<Reservation>
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
			new Reservation(new DateTime(2021, 11, 29, 8, 0, 0), new DateTime(2021, 11, 29, 9, 0, 0), Bob, Press),
			new Reservation(new DateTime(2021, 11, 29, 10, 0, 0), new DateTime(2021, 11, 29, 11, 0, 0), Bob, Zwick),
			new Reservation(new DateTime(2021, 11, 30, 9, 0, 0), new DateTime(2021, 11, 30, 11, 0, 0), Bob, Zwick),
			new Reservation(new DateTime(2021, 12, 1, 12, 0, 0), new DateTime(2021, 12, 1, 13, 0, 0), Alice, Press),
			new Reservation(new DateTime(2021, 12, 1, 15, 0, 0), new DateTime(2021, 12, 1, 17, 0, 0), Alice, Press),
			new Reservation(new DateTime(2021, 12, 2, 17, 0, 0), new DateTime(2021, 12, 2, 18, 0, 0), Alice, Press),
			new Reservation(new DateTime(2021, 12, 2, 18, 0, 0), new DateTime(2021, 12, 2, 20, 0, 0), Alice, Zwick),
			new Reservation(new DateTime(2021, 12, 3, 8, 0, 0), new DateTime(2021, 12, 3, 11, 0, 0), Bob, Press)
		};

		public IEnumerable<Reservation> GetData() => Reservations;
	}
}
