using VuzixApp.Domain.DataProviderInterfaces;
using VuzixApp.Domain.Models;

namespace VuzixApp.DAL.Providers;

public class ReservationDataProvider : IReservationDataProvider
{
	public IEnumerable<Reservation> GetLatestReservations(int count)
	{
		throw new NotImplementedException();
	}

	public Reservation GetReservation(Guid id)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<Reservation> GetReservationsByTime(DateTime since, DateTime until)
	{
		throw new NotImplementedException();
	}
}