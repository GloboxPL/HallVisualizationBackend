﻿using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using VuzixApp.Domain.DataProviderInterfaces;
using VuzixApp.Models;

namespace VuzixApp.DAL.Providers;
public class UserDataProvider : IUserDataProvider
{
	private readonly Mapper _mapper;
	private readonly MongoContext _context;

	public UserDataProvider(MongoContext mongoContext)
	{
		_context = mongoContext;
		_mapper = new Mapper(MapperSettings.Configuration);
	}

	public User AddUser(User user)
	{
		var dbUser = _mapper.Map<DatabaseModels.User>(user);
		_context.Users.InsertOne(dbUser);
		return _mapper.Map<User>(dbUser);
	}

	public User? GetUserByEmail(string email)
	{
		var dbUser = _context.Users.Find(u => u.Email == email).FirstOrDefault();
		return _mapper.Map<User>(dbUser);
	}

	public User? GetUserById(string id)
	{
		var dbUser = _context.Users.Find(u => u.Id == new ObjectId(id)).FirstOrDefault();
		return _mapper.Map<User>(dbUser);
	}
}
