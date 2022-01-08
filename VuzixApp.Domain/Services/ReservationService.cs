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

	public Reservation? GetReservation(string id)
	{
		return _reservationDataProvider.GetReservation(id);
	}

	public IEnumerable<Reservation> GetReservationsForDevice(string deviceId, DateTime? since = null,
		DateTime? until = null)
	{
		return _reservationDataProvider.GetReservationsForDevice(deviceId, since, until);
	}

	public Reservation AddReservation(DateTime start, DateTime end, string deviceId, string userId)
	{
		var reservation = new Reservation(start, end, userId, deviceId);
		var isDeviceExist = _deviceDataProvider.IsDeviceExist(deviceId);
		var isPossibleToReserve = _reservationDataProvider.IsPossibleToReserve(deviceId, start, end);
		if (!isDeviceExist || !isPossibleToReserve)
		{
			throw new Exception("Cannot reserve");
		}

		_reservationDataProvider.AddReservation(reservation);
		return reservation;
	}

	public void RemoveReservation(string id)
	{
		_reservationDataProvider.RemoveReservation(id);
	}
}