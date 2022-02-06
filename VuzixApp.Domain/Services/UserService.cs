using Microsoft.AspNetCore.Identity;
using VuzixApp.Domain.DataProviderInterfaces;
using VuzixApp.Domain.Models;

namespace VuzixApp.Domain.Services;

public class UserService : IUserService
{
	private readonly IUserDataProvider _userDataProvider;
	private readonly IPasswordHasher<User> _passwordHasher;

	public UserService(IUserDataProvider userDataProvider, IPasswordHasher<User> passwordHasher)
	{
		_userDataProvider = userDataProvider;
		_passwordHasher = passwordHasher;
	}

	public User AddUser(string email, string name, string surname, string password)
	{
		var user = new User(email, name, surname, Role.User);
		user.PasswordHash = _passwordHasher.HashPassword(user, password);
		return _userDataProvider.AddUser(user);
	}
}
