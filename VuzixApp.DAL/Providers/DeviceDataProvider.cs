using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using VuzixApp.Domain.DataProviderInterfaces;
using VuzixApp.Domain.Models;

namespace VuzixApp.DAL.Providers;

public class DeviceDataProvider : IDeviceDataProvider
{
    private readonly MongoContext _context;
    private readonly IMongoCollection<DatabaseModels.Device> _devices;
    private readonly Mapper _mapper;

    public DeviceDataProvider(MongoContext mongoContext)
    {
        _context = mongoContext;
        _devices = _context.Database.GetCollection<DatabaseModels.Device>("devices");
        _mapper = new Mapper(MapperSettings.Configuration);
    }

    public IEnumerable<Device> GetAllDevices(int hallId)
    {
        var devices = _devices.Find(x => x.HallId == hallId).ToEnumerable();
        return devices.Select(_mapper.Map<Device>);
    }

    public Device? GetDevice(string id)
    {
        var device = _devices.Find(x => x.Id == new ObjectId(id)).FirstOrDefault();
        var newDevice = new DAL.DatabaseModels.Device()
        {
            FullName = "MyDevice"
        };
        _devices.InsertOne(newDevice);
        return device != null ? _mapper.Map<Device>(device) : null;
    }
}