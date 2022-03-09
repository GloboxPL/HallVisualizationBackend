using VuzixApp.Domain.Models;

namespace VuzixApp.Domain.DataProviderInterfaces;
public interface IUserDataProvider
{
	User AddUser(User user);
	User? GetUserByEmail(string email);
	User? GetUserById(string id);
}