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
		public
			async
			System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.ActionResult<FluentResults.Result<System.Guid>>>
			Get()
		{
			Application.LogsFeature.Commands.CreateLogCommand
				command = new Application.LogsFeature.Commands.CreateLogCommand();

			FluentResults.Result<System.Guid>
				result = await Mediator.Send(command);

			// قبلا در فیلم‌های مربوطه گفتیم که دستور ذیل خطا می‌دهد
			//return result;

			if (result.IsSuccess)
			{
				return Ok(value: result);
			}
			else
			{
				return BadRequest(error: result.ToResult());
			}
		}

		#region Post (Create Log)
		[Microsoft.AspNetCore.Mvc.HttpPost]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType
			(type: typeof(FluentResults.Result<System.Guid>),
			statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType
			(type: typeof(FluentResults.Result),
			statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
		public
			async
			System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult>
			Post([Microsoft.AspNetCore.Mvc.FromBody]
			Application.LogsFeature.Commands.CreateLogCommand command)
		{
			FluentResults.Result<System.Guid>
				result = await Mediator.Send(command);

			//if (result.IsSuccess)
			//{
			//	return Ok(value: result);
			//}
			//else
			//{
			//	return BadRequest(error: result.ToResult());
			//}

			return FluentResult(result: result);
		}
		#endregion /Post (Create Log)
	}
}
