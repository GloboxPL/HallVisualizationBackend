﻿using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using VuzixApp.Domain.DataProviderInterfaces;
using VuzixApp.Models;

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
		var updateDefinition = Builders<DatabaseModels.Device>.Update
			.Set(x => x.CustomId, device.CustomId)
			.Set(x => x.HallId, device.HallId)
			.Set(x => x.Symbol, device.Symbol)
			.Set(x => x.ShortName, device.ShortName)
			.Set(x => x.FullName, device.FullName)
			.Set(x => x.Efficiency, device.Efficiency)
			.Set(x => x.Socket, device.Socket)
			.Set(x => x.Height, device.Height)
			.Set(x => x.Status, device.Status)
			.Set(x => x.StatusDescription, device.StatusDescription)
			.Set(x => x.TechnicalExaminationDate, device.TechnicalExaminationDate)
			.Set(x => x.Model3D, device.Model3D);
		_context.Devices.UpdateOne(x => x.Id == new ObjectId(device.Id), updateDefinition);
		return device;
	}
}