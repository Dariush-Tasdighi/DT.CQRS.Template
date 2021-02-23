namespace LoggingMicroservice.Api.Controllers
{
	[Microsoft.AspNetCore.Mvc.ApiController]
	[Microsoft.AspNetCore.Mvc.Route
		(template: Infrastructure.Constant.Router.Controller)]
	public class TestController : Infrastructure.ControllerBase
	{
		public TestController
			(MediatR.IMediator mediator, Dtx.Logging.ILogger<TestController> logger) : base(mediator: mediator)
		{
			Logger = logger;
		}

		protected Dtx.Logging.ILogger<TestController> Logger { get; }

		[Microsoft.AspNetCore.Mvc.HttpGet]
		public string Get()
		{
			// **************************************************
			Logger.LogTrace(message: "Trace (1)");
			Logger.LogDebug(message: "Debug (1)");
			Logger.LogInformation(message: "Information (1)");
			Logger.LogWarning(message: "Warning (1)");
			Logger.LogError(message: "Error (1)");
			Logger.LogCritical(message: "Critical (1)");
			// **************************************************

			return "Hello, World!";
		}
	}
}
