namespace VuzixApp.API.DTOs.Responses;
public class ReservationWithUser
{
	public string Id { get; }
	public DateTime Start { get; }
	public DateTime End { get; }
	public TimeSpan Duration { get; }
	public User User { get; }

	public ReservationWithUser(Models.Reservation reservation, Models.User user)
	{
		Id = reservation.Id ?? throw new ArgumentNullException("Id is null");
		Start = reservation.Start;
		End = reservation.End;
		Duration = End - Start;
		User = new User(user);
	}
}
