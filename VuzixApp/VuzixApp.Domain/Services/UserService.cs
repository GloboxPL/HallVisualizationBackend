using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VuzixApp.Domain.DataProviderInterfaces;
using VuzixApp.Domain.Models;

namespace VuzixApp.Domain.Services;

public class UserService : IUserService, IUserAuthorization
{
	private readonly IUserDataProvider _userDataProvider;
	private readonly IPasswordHasher<User> _passwordHasher;
	private readonly IHttpContextAccessor _httpContentAccessor;

	public UserService(
		IUserDataProvider userDataProvider,
		IPasswordHasher<User> passwordHasher,
		IHttpContextAccessor httpContentAccessor)
	{
		_userDataProvider = userDataProvider;
		_passwordHasher = passwordHasher;
		_httpContentAccessor = httpContentAccessor;
	}

	public User AddUser(string email, string name, string surname, string password)
	{
		var user = new User(email, name, surname, Role.User);
		user.PasswordHash = _passwordHasher.HashPassword(user, password);
		return _userDataProvider.AddUser(user);
	}

	public string GenerateJwt(string email, string password)
	{
		var user = _userDataProvider.GetUserByEmail(email);
		if (user == null)
		{
			throw new Exception("Invalid email or password.");
		}
		var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
		if (result == PasswordVerificationResult.Failed)
		{
			throw new Exception("Invalid email or password.");
		}
		return GenerateJwt(user);
	}

	public User GetUserFromHttpRequest()
	{
		var httpContext = _httpContentAccessor.HttpContext ?? throw new Exception("No HttpContext.");
		string id = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
		var user = _userDataProvider.GetUserById(id) ?? throw new Exception("User not found.");
		return user;
	}

	private static string GenerateJwt(User user)
	{
		if (user.Id == null) throw new Exception("Unknown user.");

		var claims = new List<Claim>()
		{
			new Claim(ClaimTypes.Name, $"{user.Name} {user.Surname}"),
			new Claim(ClaimTypes.NameIdentifier, user.Id),
			new Claim(ClaimTypes.Role, user.Role.ToString()),
			new Claim(ClaimTypes.Email, user.Email)
		};

		var jwtSecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY")
			?? throw new Exception("Envirnonment variable JWT_SECRET_KEY does not exist.");

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey));

		var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);

		var tokenHandler = new JwtSecurityTokenHandler();
		return tokenHandler.WriteToken(token);
	}
}
