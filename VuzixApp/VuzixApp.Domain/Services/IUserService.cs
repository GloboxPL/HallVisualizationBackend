﻿using VuzixApp.Models;

namespace VuzixApp.Domain.Services;

public interface IUserService
{
	User AddUser(string email, string name, string surname, string password);
}
