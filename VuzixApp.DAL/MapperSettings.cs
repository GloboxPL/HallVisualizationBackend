using AutoMapper;
using MongoDB.Bson;

namespace VuzixApp.DAL;

internal static class MapperSettings
{
	public static MapperConfiguration Configuration { get; }

	static MapperSettings()
	{
		Configuration = new MapperConfiguration(config =>
			{
				//DAL to Domain
				config.CreateMap<DatabaseModels.Device, Domain.Models.Device>();
				config.CreateMap<DatabaseModels.Reservation, Domain.Models.Reservation>();
				config.CreateMap<DatabaseModels.User, Domain.Models.User>();

				//Domain to DAL
				config.CreateMap<string?, ObjectId>().ConvertUsing(s => StringToObjectId(s));
				config.CreateMap<Domain.Models.Device, DatabaseModels.Device>();
				config.CreateMap<Domain.Models.Reservation, DatabaseModels.Reservation>();
				config.CreateMap<Domain.Models.User, DatabaseModels.User>();
			}
		);
	}

	private static ObjectId StringToObjectId(string? id)
	{
		if (string.IsNullOrEmpty(id))
		{
			return new ObjectId();
		}
		return new ObjectId(id);
	}
}