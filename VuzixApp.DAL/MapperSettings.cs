using AutoMapper;

namespace VuzixApp.DAL;

internal static class MapperSettings
{
    public static MapperConfiguration Configuration { get; }

    static MapperSettings()
    {
        Configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<DatabaseModels.Device, Domain.Models.Device>();
                x.CreateMap<DatabaseModels.Reservation, Domain.Models.Reservation>();
                x.CreateMap<DatabaseModels.User, Domain.Models.User>();
            }
        );
    }
}