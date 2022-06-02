using VuzixApp.Models;

namespace VuzixApp.Domain.DataProviderInterfaces;

public interface IDeviceDataProvider
{
    Device? GetDevice(string id);
    bool IsDeviceExist(string id);
    IEnumerable<Device> GetAllDevices(int? hallId = null);
    Device UpdateDevice(Device device);
}