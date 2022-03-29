using VuzixApp.Domain.Models;

namespace VuzixApp.Domain.Services;

public interface IUserService
{
	User AddUser(string email, string name, string surname, string password);
	public User GetUserFromHttpRequest();
	string GenerateJwt(string email, string password);
}
