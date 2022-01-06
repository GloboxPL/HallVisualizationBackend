namespace VuzixApp.API.DTO;

public class AddReservationRequest
{
    public DateTime Start;
    public DateTime End;
    public string DeviceId = string.Empty;
}