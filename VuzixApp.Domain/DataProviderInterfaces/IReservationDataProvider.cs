using VuzixApp.Domain.Models;

namespace VuzixApp.Domain.DataProviderInterfaces;

public interface IReservationDataProvider
{
    Reservation AddReservation(Reservation reservation);
    bool IsPossibilityToReserve(string deviceId, DateTime start, DateTime end);
}