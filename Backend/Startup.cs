using Microsoft.OpenApi.Models;
using VuzixApp.DAL;
using VuzixApp.DAL.Providers;
using VuzixApp.Domain.DataProviderInterfaces;
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
		services.AddControllers();
		services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend", Version = "v1" });
		});

		// DAL
		services.AddSingleton(
			context => new MongoContext(
				Configuration.GetConnectionString("Mongo"),
				Configuration.GetSection("Mongo")["Database"])
			);
		services.AddScoped<IDeviceDataProvider, DeviceDataProvider>();

		// Domain
		services.AddScoped<IDeviceService, DeviceService>();
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VuzixApp v1"));
		}

		app.UseHttpsRedirection();

		app.UseRouting();

		app.UseAuthorization();

		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllers();
		});
	}
}