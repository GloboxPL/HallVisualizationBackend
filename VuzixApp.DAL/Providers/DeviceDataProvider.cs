using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using VuzixApp.Domain.DataProviderInterfaces;
using VuzixApp.Domain.Models;
using Reservation = VuzixApp.DAL.DatabaseModels.Reservation;
using User = VuzixApp.DAL.DatabaseModels.User;

namespace VuzixApp.DAL.Providers;

public class DeviceDataProvider : IDeviceDataProvider
{
	private readonly Mapper _mapper;
	private readonly MongoContext _context;

	public DeviceDataProvider(MongoContext mongoContext)
	{
		_context = mongoContext;
		_mapper = new Mapper(MapperSettings.Configuration);
	}


	public Device? GetDevice(string id)
	{
		var device = _context.Devices.Find(x => x.Id == new ObjectId(id)).FirstOrDefault();
		return _mapper.Map<Device>(device);
	}

	public bool IsDeviceExist(string id)
	{
		return _context.Devices.Find(x => x.Id == new ObjectId(id)).Any();
	}

	public IEnumerable<Device> GetAllDevices(int? hallId = null)
	{
		var devices = hallId == null
			? _context.Devices.Find(_ => true).ToEnumerable()
			: _context.Devices.Find(x => x.HallId == hallId).ToEnumerable();
		return devices.Select(_mapper.Map<Device>);
	}

	public Device UpdateDevice(Device device)
	{
		throw new NotImplementedException();
	}
}