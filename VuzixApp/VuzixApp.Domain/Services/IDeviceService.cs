using VuzixApp.Domain.Models;

namespace VuzixApp.Domain.Services;

public interface IDeviceService
{
	Device? GetDevice(string id);
	Device UpdateDevice(
		string id,
		int? customId,
		int? hallId,
		string? symbol,
		string? shortName,
		string? fullName,
		int? efficiency,
		string? socket,
		int? height,
		DeviceStatus? status,
		string? statusDescription,
		DateTime? technicalExaminationDate,
		string? model3D);
	IEnumerable<Device> GetAllDevices();
	byte[] GenerateQrCode(string id);
}