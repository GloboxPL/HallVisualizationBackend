﻿using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.CaseBasedReasoning.Reservations
{
	public class ReservationReuse : IReuse<Reservation>
	{
		private readonly IReservationChecker _checker;
		private readonly ReservationRule _rule;
		private string person;
		private Device device;

		public ReservationReuse(IReservationChecker checker, ReservationRule rule)
		{
			_checker = checker;
			_rule = rule;
		}

		IEnumerable<Reservation> IReuse<Reservation>.GetAdaptedCases(IEnumerable<Reservation> cases)
		{
			person = cases.First().Person;
			device = cases.First().Device;
			var aggregation = new AggregatedReservations(cases.ToList()); //should contain all needed stats
			var since = RoundTime(_rule.Since ?? DateTime.Now, new TimeSpan(0, 5, 0));
			var until = _rule.Until ?? since.AddDays(7);
			var duration = TimeSpan.FromHours(1);
			IEnumerable<Reservation> possibilities = GetPossibilities(since, until, duration);
			IEnumerable<Reservation> bestFitted = ChooseBestFitted(possibilities, aggregation);
			return bestFitted.OrderBy(x => x.Start);
		}

		private IEnumerable<Reservation> ChooseBestFitted(IEnumerable<Reservation> possibilities, AggregatedReservations aggregation)
		{
			// na razie max 7
			var bestFitted = new List<Reservation>();
			for (int i = 1; i <= 7; i++)
			{
				var reservationForDay = possibilities.Where(x => (int)x.Start.DayOfWeek == i % 7);
				if (reservationForDay != null && reservationForDay.Any())
				{
					var scores = reservationForDay.Select(x => (Score(x.Start, (int)aggregation._medianHours[i - 1]), x)).OrderBy(x => x.Item1).AsEnumerable();
					bestFitted.Add(scores.First().Item2);
				}
			}
			return bestFitted;
		}

		private static DateTime RoundTime(DateTime dateTime, TimeSpan precision)
		{
			long ticks = (dateTime.Ticks + (precision.Ticks / 2) + 1) / precision.Ticks;
			return new DateTime(ticks * precision.Ticks, dateTime.Kind);
		}

		private static int Score(DateTime dateTime, int hour)
		{
			return Math.Abs(dateTime.Hour * 60 + dateTime.Minute - hour * 60);
		}

		private IEnumerable<Reservation> GetPossibilities(DateTime since, DateTime until, TimeSpan duration)
		{
			var possibilities = new List<Reservation>();
			var freeTimes = _checker.GetFreeTimes(since, until);

			foreach (var freeTime in freeTimes)
			{
				var newStart = freeTime.Item1;//round
				var newEnd = newStart + duration;
				while (newStart >= freeTime.Item1 && newEnd <= freeTime.Item2) // czy 1 warunek potrzebny?
				{
					possibilities.Add(new Reservation(newStart, newEnd, person, device));
					newStart = newStart.AddMinutes(5);
					newEnd = newStart + duration;
				}
			}
			return possibilities;
		}

		Reservation? IReuse<Reservation>.Adapt(Reservation reservation)
		{
			throw new NotImplementedException();
		}
	}

	internal class AggregatedReservations
	{
		public readonly List<Reservation>[] _reservations = new List<Reservation>[7];
		public readonly int[] _medianHours = new int[7];

		public List<Reservation> Monday => _reservations[0];
		public List<Reservation> Tuesday => _reservations[1];
		public List<Reservation> Wednesday => _reservations[2];
		public List<Reservation> Thursday => _reservations[3];
		public List<Reservation> Friday => _reservations[4];
		public List<Reservation> Saturday => _reservations[5];
		public List<Reservation> Sunday => _reservations[6];

		public int MondayHour => _medianHours[0];

		public AggregatedReservations(List<Reservation> reservations)
		{
			for (int i = 0; i < 7; i++)
			{
				_medianHours[i] = 8;
				_reservations[i] = new List<Reservation>();
			}
			foreach (var reservation in reservations)
			{
				switch (reservation.Start.DayOfWeek)
				{
					case DayOfWeek.Sunday:
						Sunday.Add(reservation);
						break;
					case DayOfWeek.Monday:
						Monday.Add(reservation);
						break;
					case DayOfWeek.Tuesday:
						Tuesday.Add(reservation);
						break;
					case DayOfWeek.Wednesday:
						Wednesday.Add(reservation);
						break;
					case DayOfWeek.Thursday:
						Thursday.Add(reservation);
						break;
					case DayOfWeek.Friday:
						Friday.Add(reservation);
						break;
					case DayOfWeek.Saturday:
						Saturday.Add(reservation);
						break;
				}
			}
			for (int i = 0; i < 7; i++)
			{
				if (_reservations[i].Any())
				{
					_medianHours[i] = _reservations[i].GroupBy(r => r.Start.Hour).OrderByDescending(h => h.Count()).Select(g => g.Key).First();
				}
			}
		}

	}
}
