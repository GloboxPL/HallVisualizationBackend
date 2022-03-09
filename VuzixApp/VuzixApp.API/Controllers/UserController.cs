﻿using Microsoft.AspNetCore.Mvc;
using VuzixApp.API.DTOs.Responses;
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
		var user = new User(_userService.AddUser(email, name, surname, password));
		return Task.FromResult(user);
	}

	[HttpPost("login")]
	public Task<string> Login([FromForm] string email, [FromForm] string password)
	{
		var token = _userService.GenerateJwt(email, password);
		return Task.FromResult(token);
	}
}
