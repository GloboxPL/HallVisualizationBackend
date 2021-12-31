namespace VuzixApp.Domain.Models;

public class Device
{
    public string Id { get; init; } = string.Empty;
    public int CustomId { get; set; }
    public int HallId { get; set; }
    public string Symbol { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public int Efficiency { get; set; }
    public string Socket { get; set; } = string.Empty;
    public int Height { get; set; }
    public DeviceStatus Status { get; set; } = DeviceStatus.Wyłączona;
    public string StatusDescription { get; set; } = string.Empty;
    public IEnumerable<Reservation> Reservations { get; } = new List<Reservation>();
    public DateTime TechnicalExaminationDate { get; set; }
}