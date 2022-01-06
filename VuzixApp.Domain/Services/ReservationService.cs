using VuzixApp.Domain.DataProviderInterfaces;
using VuzixApp.Domain.Models;

namespace VuzixApp.Domain.Services;

public class ReservationService : IReservationService
{
    private readonly IReservationDataProvider _reservationDataProvider;
    private readonly IDeviceDataProvider _deviceDataProvider;

    public ReservationService(IReservationDataProvider reservationDataProvider, IDeviceDataProvider deviceDataProvider)
    {
        _reservationDataProvider = reservationDataProvider;
        _deviceDataProvider = deviceDataProvider;
    }

    public Reservation AddReservation(DateTime start, DateTime end, string deviceId, string userId)
    {
        var reservation = new Reservation(start, end, userId, deviceId);
        if (!_deviceDataProvider.IsDeviceExist(deviceId) ||
            _reservationDataProvider.IsPossibilityToReserve(deviceId, start, end))
        {
            throw new Exception("Cannot reserve");
        }

        _reservationDataProvider.AddReservation(reservation);
        return reservation;
    }

    public void RemoveReservation(string id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Reservation> GetReservationsForDevice(string deviceId, DateTime? since = null,
        DateTime? until = null)
    {
        throw new NotImplementedException();
    }
}