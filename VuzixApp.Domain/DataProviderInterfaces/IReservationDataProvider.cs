using VuzixApp.Domain.Models;

namespace VuzixApp.Domain.DataProviderInterfaces;

public interface IReservationDataProvider
{
	Reservation GetReservation(Guid id);
	IEnumerable<Reservation> GetLatestReservations(int count);
	IEnumerable<Reservation> GetReservationsByTime(DateTime since, DateTime until);

}
