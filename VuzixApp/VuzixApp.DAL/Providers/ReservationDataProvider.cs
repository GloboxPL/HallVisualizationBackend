using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using VuzixApp.CBR;
using VuzixApp.Domain.DataProviderInterfaces;
using VuzixApp.Domain.Models;

namespace VuzixApp.DAL.Providers;

public class ReservationDataProvider : IReservationDataProvider, IRetrieve<Reservation>
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

	public Reservation? GetReservation(string id)
	{
		var reservation = _context.Reservations.Find(r => r.Id == new ObjectId(id)).FirstOrDefault();
		return _mapper.Map<Reservation>(reservation);
	}

	public IEnumerable<Reservation> GetReservationsForDevice(string deviceId, DateTime? since = null, DateTime? until = null)
	{
		since ??= DateTime.MinValue;
		until ??= DateTime.MaxValue;
		var reservations = _context.Reservations.Find(r => r.DeviceId == new ObjectId(deviceId) && r.Start < until && r.End > since).ToEnumerable();
		return reservations.Select(_mapper.Map<Reservation>);
	}

	public IEnumerable<Reservation> GetSimilarCases(params object[] objs)
	{
		if (objs.Length != 2) throw new Exception("Invalid params.");
		try
		{
			var userId = new ObjectId(objs[0].ToString());
			var deviceId = new ObjectId(objs[1].ToString());
			//TODO change way of throwing an exception
			var reservations = _context.Reservations.Find(r => r.UserId == userId).ToEnumerable();
			return reservations.Select(_mapper.Map<Reservation>);
		}
		catch (Exception e)
		{
			throw new Exception("Invalid params.", e);
		}
	}

	public bool IsPossibleToReserve(string deviceId, DateTime start, DateTime end)
	{
		return !_context.Reservations.AsQueryable().Any(r =>
			  r.DeviceId == new ObjectId(deviceId) && r.Start < end && r.End > start);
	}

	public void RemoveReservation(string id)
	{
		var deletedCount = _context.Reservations.DeleteOne(r => r.Id == new ObjectId(id)).DeletedCount;
		if (deletedCount == 0)
		{
			throw new Exception("Reservation not found");
		}
	}
}