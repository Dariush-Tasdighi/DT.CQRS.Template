using FluentValidation.AspNetCore;
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

			// AddFluentValidation->Extension Method-> using FluentValidation.AspNetCore;
			//services.AddControllers()
			//	.AddFluentValidation(current =>
			//	{
			//		current.RegisterValidatorsFromAssemblyContaining
			//			<Application.LogsFeature.Commands.CreateLogCommandValidator>();

			//		current.LocalizationEnabled = true; // Default: [true]
			//		current.AutomaticValidationEnabled = true; // Default: [true]
			//		current.ImplicitlyValidateChildProperties = false; // Default: [false]
			//		current.ImplicitlyValidateRootCollectionElements = false; // Default: [false]
			//		current.RunDefaultMvcValidationAfterFluentValidationExecutes = false; // Default: [true]
			//	});

			Core.DependencyContainer.ConfigureServices
				(configuration: Configuration, services: services);
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
