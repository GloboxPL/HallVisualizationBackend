using VuzixApp.Domain.DataProviderInterfaces;
using VuzixApp.Models;

namespace VuzixApp.Domain.Services;

public class ReservationService : IReservationService
{
	private readonly IReservationDataProvider _reservationDataProvider;
	private readonly IDeviceDataProvider _deviceDataProvider;
	private readonly IUserDataProvider _userDataProvider;
	private readonly IUserService _userService;
	private readonly IUserAuthorization _userAuthorization;


	public ReservationService(
		IReservationDataProvider reservationDataProvider,
		IDeviceDataProvider deviceDataProvider,
		IUserDataProvider userDataProvider,
		IUserService userService,
		IUserAuthorization userAuthorization)
	{
		_reservationDataProvider = reservationDataProvider;
		_deviceDataProvider = deviceDataProvider;
		_userDataProvider = userDataProvider;
		_userService = userService;
		_userAuthorization = userAuthorization;
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

	public Reservation AddReservation(DateTime start, DateTime end, string deviceId)
	{
		var user = _userAuthorization.GetUserFromHttpRequest();
		var reservation = new Reservation(start, end, user.Id!, deviceId);
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

	public IEnumerable<User> GetUsersForReservations(IEnumerable<Reservation> reservations)
	{
		var users = new Dictionary<string, User>();
		foreach (var reservation in reservations)
		{
			if (!users.ContainsKey(reservation.UserId))
			{
				var user = _userDataProvider.GetUserById(reservation.UserId);
				if (user == null) throw new Exception();
				users.Add(user.Id!, user);
			}
		}
		return users.Values;
	}
}