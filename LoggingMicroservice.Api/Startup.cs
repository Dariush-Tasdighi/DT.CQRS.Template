using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace LoggingMicroservice.Api
{
	public class Startup : object
	{
		public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration) : base()
		{
			Configuration = configuration;
		}

		protected Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

		public void ConfigureServices
			(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
		{
			services.AddControllers();

			// **************************************************
			services.AddTransient<Persistence.IUnitOfWork, Persistence.UnitOfWork>(current =>
			{
				string databaseConnectionString =
					Configuration
					.GetSection(key: "ConnectionStrings")
					.GetSection(key: "CommandsConnectionString")
					.Value;

				string databaseProviderString =
					Configuration
					.GetSection(key: "CommandsDatabaseProvider")
					.Value;

				Dtx.Persistence.Enums.Provider databaseProvider =
					(Dtx.Persistence.Enums.Provider)
					System.Convert.ToInt32(databaseProviderString);

				Dtx.Persistence.Options options =
					new Dtx.Persistence.Options
					{
						Provider = databaseProvider,
						ConnectionString = databaseConnectionString,
					};

				return new Persistence.UnitOfWork(options: options);
			});
			// **************************************************

			Core.DependencyContainer.ConfigureServices(services: services);
		}

		public void Configure
			(Microsoft.AspNetCore.Builder.IApplicationBuilder app,
			Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
