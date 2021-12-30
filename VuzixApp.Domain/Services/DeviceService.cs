using VuzixApp.Domain.DataProviderInterfaces;
using VuzixApp.Domain.Models;

namespace VuzixApp.Domain.Services;

public class DeviceService : IDeviceService
{
	private readonly IDeviceDataProvider _deviceDataProvider;

	public DeviceService(IDeviceDataProvider deviceDataProvider)
	{
		_deviceDataProvider = deviceDataProvider;
	}

	public IEnumerable<Device> GetAllDevices()
	{
		return _deviceDataProvider.GetAllDevices(0);
	}

	public Device GetDevice(string id)
	{
		return _deviceDataProvider.GetDevice(id);
	}
}
