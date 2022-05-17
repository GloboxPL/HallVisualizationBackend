using VuzixApp.Domain.Models;

namespace VuzixApp.Domain.Services;

public interface IUserAuthorization
{
	User GetUserFromHttpRequest();
	string GenerateJwt(string email, string password);
}

