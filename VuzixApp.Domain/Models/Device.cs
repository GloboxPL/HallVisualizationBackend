namespace VuzixApp.Domain.Models;

public class Device
{
	public string Id { get; set; }
	public int CustomId { get; set; }
	public int HallId { get; set; }
	public string Symbol { get; set; }
	public string ShortName { get; set; }
	public string FullName { get; set; }
	public int Efficiency { get; set; }
	public string Socket { get; set; }
	public int Height { get; set; }
}