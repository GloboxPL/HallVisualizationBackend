using QRCoder;
using VuzixApp.Domain.DataProviderInterfaces;
using VuzixApp.Models;

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
		return _deviceDataProvider.GetAllDevices();
	}

	public Device? GetDevice(string id)
	{
		return _deviceDataProvider.GetDevice(id);
	}

	public Device UpdateDevice(string id, int? customId, int? hallId, string? symbol, string? shortName, string? fullName, int? efficiency, string? socket, int? height, DeviceStatus? status, string? statusDescription, DateTime? technicalExaminationDate, string? model3D)
	{
		var device = GetDevice(id);
		if (device == null)
		{
			throw new Exception("Device not found");
		}
		device.CustomId = customId ?? device.CustomId;
		device.HallId = hallId ?? device.HallId;
		device.Symbol = symbol ?? device.Symbol;
		device.ShortName = shortName ?? device.ShortName;
		device.FullName = fullName ?? device.FullName;
		device.Efficiency = efficiency ?? device.Efficiency;
		device.Socket = socket ?? device.Socket;
		device.Height = height ?? device.Height;
		device.Status = status ?? device.Status;
		device.StatusDescription = statusDescription ?? device.StatusDescription;
		device.TechnicalExaminationDate = technicalExaminationDate ?? device.TechnicalExaminationDate;
		device.Model3D = model3D ?? device.Model3D;

		_deviceDataProvider.UpdateDevice(device);
		return device;
	}
}
