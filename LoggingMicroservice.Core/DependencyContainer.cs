using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace LoggingMicroservice.Core
{
	public static class DependencyContainer : object
	{
		static DependencyContainer()
		{
		}

		public static void ConfigureServices
			(Microsoft.Extensions.Configuration.IConfiguration configuration,
			Microsoft.Extensions.DependencyInjection.IServiceCollection services)
		{
			// **************************************************
			// AddMediatR() -> Extension Method -> using MediatR;
			// GetTypeInfo() -> Extension Method -> using System.Reflection;
			services.AddMediatR
				(typeof(Application.LogsFeature.MappingProfile).GetTypeInfo().Assembly);
			// **************************************************

			// **************************************************
			// using Microsoft.Extensions.DependencyInjection;
			services.AddAutoMapper(typeof(Application.LogsFeature.MappingProfile));
			// **************************************************

			// **************************************************
			services.AddTransient<Persistence.IUnitOfWork, Persistence.UnitOfWork>(current =>
			{
				string databaseConnectionString =
					configuration
					.GetSection(key: "ConnectionStrings")
					.GetSection(key: "CommandsConnectionString")
					.Value;

				string databaseProviderString =
					configuration
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

			// **************************************************
			services.AddTransient<Persistence.IQueryUnitOfWork, Persistence.QueryUnitOfWork>(current =>
			{
				string databaseConnectionString =
					configuration
					.GetSection(key: "ConnectionStrings")
					.GetSection(key: "QueriesConnectionString")
					.Value;

				string databaseProviderString =
					configuration
					.GetSection(key: "QueriesDatabaseProvider")
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

				return new Persistence.QueryUnitOfWork(options: options);
			});
			// **************************************************
		}
	}
}
