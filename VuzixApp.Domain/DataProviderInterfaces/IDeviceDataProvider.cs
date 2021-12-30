using VuzixApp.Domain.Models;

namespace VuzixApp.Domain.DataProviderInterfaces;

public interface IDeviceDataProvider
{
	Device? GetDevice(string id);
	IEnumerable<Device> GetAllDevices(int hallId);
}