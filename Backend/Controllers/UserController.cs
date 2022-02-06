using Microsoft.AspNetCore.Mvc;
using VuzixApp.Domain.Models;
using VuzixApp.Domain.Services;

namespace VuzixApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
	private readonly ILogger<UserController> _logger;
	private readonly IUserService _userService;

	public UserController(ILogger<UserController> logger, IUserService userService)
	{
		_logger = logger;
		_userService = userService;
	}

	[HttpPost("register")]
	public Task<User> AddUser([FromForm] string email, [FromForm] string name, [FromForm] string surname, [FromForm] string password)
	{
		var user = _userService.AddUser(email, name, surname, password);
		return Task.FromResult(user);
	}
}

