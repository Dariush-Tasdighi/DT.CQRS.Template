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
			(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
		{
			// AddMediatR() -> Extension Method -> using MediatR;
			// GetTypeInfo() -> Extension Method -> using System.Reflection;
			services.AddMediatR
				(typeof(Application.LogsFeature.MappingProfile).GetTypeInfo().Assembly);

			// using Microsoft.Extensions.DependencyInjection;
			services.AddAutoMapper(typeof(Application.LogsFeature.MappingProfile));
		}
	}
}
