using VuzixApp.Domain.Models;

namespace VuzixApp.Domain.Services;

public interface IDeviceService
{
	Device GetDevice(string id);
	IEnumerable<Device> GetAllDevices();
}