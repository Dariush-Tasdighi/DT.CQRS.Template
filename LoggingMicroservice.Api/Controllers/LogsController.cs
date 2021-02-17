namespace LoggingMicroservice.Api.Controllers
{
	[Microsoft.AspNetCore.Mvc.ApiController]
	[Microsoft.AspNetCore.Mvc.Route
		(template: Infrastructure.Constant.Router.Controller)]
	public class LogsController : Infrastructure.ControllerBase
	{
		public LogsController(MediatR.IMediator mediator) : base(mediator: mediator)
		{
		}

		[Microsoft.AspNetCore.Mvc.HttpGet]
		public FluentResults.Result<System.Guid> Get()
		{
			//return "Hello, World!";

			Application.LogsFeature.Commands.CreateLogCommand
				command = new Application.LogsFeature.Commands.CreateLogCommand();

			FluentResults.Result<System.Guid>
				result = Mediator.Send(command).Result;

			return result;
		}

		//#region Post
		//[Microsoft.AspNetCore.Mvc.HttpPost]

		//[Microsoft.AspNetCore.Mvc.ProducesResponseType
		//	(type: typeof(FluentResults.Result<System.Guid>),
		//	statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

		//[Microsoft.AspNetCore.Mvc.ProducesResponseType
		//	(type: typeof(FluentResults.Result),
		//	statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound)]
		//public
		//	async
		//	System.Threading.Tasks.Task
		//	<Microsoft.AspNetCore.Mvc.ActionResult<Domain.Models.Log>>
		//	Post(int id)
		//{
		//	Models.User user = null;

		//	await System.Threading.Tasks.Task.Run(() =>
		//	{
		//		user =
		//			Users
		//			.Where(current => current.Id == id)
		//			.FirstOrDefault();
		//	});

		//	if (user == null)
		//	{
		//		return NotFound(value: "User not found!");
		//	}
		//	else
		//	{
		//		return Ok(value: user);
		//	}
		//}
		//#endregion /Get By Id Method	}
	}
}
