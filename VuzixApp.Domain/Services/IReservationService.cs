using VuzixApp.Domain.Models;

namespace VuzixApp.Domain.Services;

public interface IReservationService
{
	Reservation AddReservation(DateTime start, DateTime end, string deviceId, string userId);
	void RemoveReservation(string id);
	IEnumerable<Reservation> GetReservationsForDevice(string deviceId, DateTime? since = null, DateTime? until = null);
	Reservation? GetReservation(string id);
}