using VuzixApp.Models;

namespace VuzixApp.Domain.DataProviderInterfaces;

public interface IReservationDataProvider
{
	Reservation? GetReservation(string id);
	Reservation AddReservation(Reservation reservation);
	IEnumerable<Reservation> GetReservationsForDevice(string deviceId, DateTime? since = null, DateTime? until = null);
	void RemoveReservation(string id);
	bool IsPossibleToReserve(string deviceId, DateTime start, DateTime end);
}