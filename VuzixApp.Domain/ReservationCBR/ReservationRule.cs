namespace VuzixApp.Domain.ReservationCBR;

public class ReservationRule
{
	public DateTime? Since { get; init; }
	public DateTime? Until { get; init; }
	public TimeSpan? Duration { get; init; }
	public string Person { get; }
	public string DeviceFullName { get; }

	public ReservationRule(string person, string deviceFullName)
	{
		Person = person;
		DeviceFullName = deviceFullName;
	}
}