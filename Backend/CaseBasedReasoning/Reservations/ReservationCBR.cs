﻿using Backend.Models;

namespace Backend.CaseBasedReasoning.Reservations
{
	public class ReservationCBR : CBR<Reservation>
	{
		protected override IRetrieve<Reservation> Retrieve { get; }
		protected override IReuse<Reservation> Reuse { get; }

		public ReservationCBR(IDataSource<Reservation> dataSource, IReservationChecker checker, ReservationRule rule, string person, string device) : base(dataSource)
		{
			Retrieve = new ReservationRetrieve(_dataSource, person, device);
			Reuse = new ReservationReuse(checker, rule);
		}

	}
}
