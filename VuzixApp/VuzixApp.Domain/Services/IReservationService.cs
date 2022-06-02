using VuzixApp.Models;

namespace VuzixApp.Domain.Services;

public interface IReservationService
{
	Reservation AddReservation(DateTime start, DateTime end, string deviceId);
	void RemoveReservation(string id);
	IEnumerable<Reservation> GetReservationsForDevice(string deviceId, DateTime? since = null, DateTime? until = null);
	IEnumerable<User> GetUsersForReservations(IEnumerable<Reservation> reservations);
	Reservation? GetReservation(string id);
}