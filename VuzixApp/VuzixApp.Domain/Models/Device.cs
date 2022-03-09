namespace VuzixApp.Domain.Models;

public class Device
{
	public string? Id { get; init; }
	public int CustomId { get; set; }
	public int HallId { get; set; }
	public string Symbol { get; set; } = string.Empty;
	public string ShortName { get; set; } = string.Empty;
	public string FullName { get; set; } = string.Empty;
	public int Efficiency { get; set; }
	public string Socket { get; set; } = string.Empty;
	public int Height { get; set; }
	public DeviceStatus Status { get; set; } = DeviceStatus.Off;
	public string StatusDescription { get; set; } = string.Empty;
	public DateTime TechnicalExaminationDate { get; set; }
	public string Model3D { get; set; }
}