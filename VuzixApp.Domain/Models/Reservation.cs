namespace VuzixApp.Domain.Models;

public class Reservation
{
    public string Id { get; init; } = string.Empty;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public TimeSpan Duration => End - Start;
    public string UserId { get; }
    public string DeviceId { get; }

    public Reservation(DateTime start, DateTime end, string userId, string deviceId)
    {
        Validate(start, end);
        Start = start;
        End = end;
        UserId = userId;
        DeviceId = deviceId;
    }

    private static void Validate(DateTime start, DateTime end)
    {
        if (start >= end) throw new ArgumentException("Start date should be earlier than end date");
    }
}