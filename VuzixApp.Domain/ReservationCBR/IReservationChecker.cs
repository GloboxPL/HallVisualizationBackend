using VuzixApp.Domain.Models;

namespace VuzixApp.Domain.ReservationCBR;

public interface IReservationChecker
{
	IEnumerable<Tuple<DateTime, DateTime>> GetFreeTimes(DateTime since, DateTime until);
	bool IsvalidSolution(Reservation reservation);
}