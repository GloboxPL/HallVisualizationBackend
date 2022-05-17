using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using VuzixApp.CBR;
using VuzixApp.DAL;
using VuzixApp.DAL.Providers;
using VuzixApp.Domain.DataProviderInterfaces;
using VuzixApp.Domain.Models;
using VuzixApp.Domain.Services;

namespace VuzixApp.API;

public class Startup
{
	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public IConfiguration Configuration { get; }

	public void ConfigureServices(IServiceCollection services)
	{
		// Common
		services.AddAuthentication(option =>
		{
			option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

		}).AddJwtBearer(cfg =>
		{
			var jwtSecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
			if (string.IsNullOrEmpty(jwtSecretKey))
			{
				throw new Exception("Envirnonment variable JWT_SECRET_KEY does not exist.");
			}
			cfg.RequireHttpsMetadata = false; // TODO remove
			cfg.SaveToken = true;
			cfg.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = false,
				ValidateAudience = false,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey))
			};
		});
		services.AddControllers();
		services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo { Title = "VuzixApp", Version = "v1" });
			c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
			{
				Name = "Authorization",
				Type = SecuritySchemeType.ApiKey,
				Scheme = JwtBearerDefaults.AuthenticationScheme,
				BearerFormat = "JWT",
				In = ParameterLocation.Header,
				Description = "JWT Authorization header using the Bearer scheme."
			});
			c.AddSecurityRequirement(new OpenApiSecurityRequirement {
			{
				new OpenApiSecurityScheme {
					Reference = new OpenApiReference {
						Type = ReferenceType.SecurityScheme,
						Id = JwtBearerDefaults.AuthenticationScheme
					}
				},
				new string[] {}
			}});
		});
		services.AddHttpContextAccessor();

		// DAL
		services.AddSingleton(
			context => new MongoContext(
				Configuration.GetConnectionString("Mongo"),
				Configuration.GetSection("Mongo")["Database"])
			);
		services.AddScoped<IDeviceDataProvider, DeviceDataProvider>();
		services.AddScoped<IReservationDataProvider, ReservationDataProvider>();
		services.AddScoped<IRetrieve<Reservation>, ReservationDataProvider>();
		services.AddScoped<IUserDataProvider, UserDataProvider>();

		// Domain
		services.AddScoped<IDeviceService, DeviceService>();
		services.AddScoped<IReservationService, ReservationService>();
		services.AddScoped<IUserService, UserService>();
		services.AddScoped<IUserAuthorization, UserService>();
		services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}
		app.UseSwagger();
		app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));

		app.UseAuthentication();

		app.UseHttpsRedirection();

		app.UseRouting();

		app.UseAuthorization();

		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllers();
		});
	}
}