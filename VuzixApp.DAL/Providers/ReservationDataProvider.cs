using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using VuzixApp.Domain.DataProviderInterfaces;
using VuzixApp.Domain.Models;

namespace VuzixApp.DAL.Providers;

public class ReservationDataProvider : IReservationDataProvider
{
    private readonly Mapper _mapper;
    private readonly MongoContext _context;

    public ReservationDataProvider(MongoContext mongoContext)
    {
        _context = mongoContext;
        _mapper = new Mapper(MapperSettings.Configuration);
    }

    public Reservation AddReservation(Reservation reservation)
    {
        var dbReservation = _mapper.Map<DatabaseModels.Reservation>(reservation);
        _context.Reservations.InsertOne(dbReservation);
        reservation.Id = dbReservation.Id.ToString();
        return reservation;
    }

    public bool IsPossibilityToReserve(string deviceId, DateTime start, DateTime end)
    {
        return _context.Reservations.AsQueryable().Any(x =>
            x.DeviceId == new ObjectId(deviceId) && x.Start < end && x.End > start);
    }
}