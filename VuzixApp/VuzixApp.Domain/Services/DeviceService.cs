using QRCoder;
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

	public byte[] GenerateQrCode(string id)
	{
		if (!_deviceDataProvider.IsDeviceExist(id))
		{
			throw new Exception("Device not found");
		}
		var qrCodeData = new QRCodeGenerator().CreateQrCode(id, QRCodeGenerator.ECCLevel.Q);
		return new PngByteQRCode(qrCodeData).GetGraphic(25);
	}

	public IEnumerable<Device> GetAllDevices()
	{
		return _deviceDataProvider.GetAllDevices(0);
	}

	public Device? GetDevice(string id)
	{
		return _deviceDataProvider.GetDevice(id);
	}
}
