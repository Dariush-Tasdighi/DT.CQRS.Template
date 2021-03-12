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

		//#region Post (Create Log)
		//[Microsoft.AspNetCore.Mvc.HttpPost]

		//[Microsoft.AspNetCore.Mvc.ProducesResponseType
		//	(type: typeof(FluentResults.Result<System.Guid>),
		//	statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

		//[Microsoft.AspNetCore.Mvc.ProducesResponseType
		//	(type: typeof(FluentResults.Result),
		//	statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
		//public
		//	async
		//	System.Threading.Tasks.Task
		//	<Microsoft.AspNetCore.Mvc.IActionResult>
		//	Post([Microsoft.AspNetCore.Mvc.FromBody]
		//	Application.LogsFeature.Commands.CreateLogCommand command)
		//{
		//	// **************************************************
		//	//FluentResults.Result<System.Guid>
		//	//	result = await Mediator.Send<FluentResults.Result<System.Guid>>(command);
		//	// **************************************************

		//	// **************************************************
		//	//FluentResults.Result<System.Guid>
		//	//	result = await Mediator.Send(command);
		//	// **************************************************

		//	// **************************************************
		//	var result =
		//		await Mediator.Send(command);
		//	// **************************************************

		//	// **************************************************
		//	//if (result.IsSuccess)
		//	//{
		//	//	return Ok(value: result);
		//	//}
		//	//else
		//	//{
		//	//	return BadRequest(error: result.ToResult());
		//	//}
		//	// **************************************************

		//	// **************************************************
		//	//return FluentResult<System.Guid>(result: result);
		//	// **************************************************

		//	// **************************************************
		//	return FluentResult(result: result);
		//	// **************************************************
		//}
		//#endregion /Post (Create Log)

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
			var result =
				await Mediator.Send(command);

			return FluentResult(result: result);
		}
		#endregion /Post (Create Log)

		#region Get (Get Some Logs)
		[Microsoft.AspNetCore.Mvc.HttpGet(template: "{count}")]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType
			(type: typeof(FluentResults.Result<System.Collections.Generic.IList<Domain.ViewModels.GetLogsQueryResponseViewModel>>),
			statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType
			(type: typeof(FluentResults.Result),
			statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
		public
			async
			System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult>
			Get(int? count)
		{
			Application.LogsFeature.Queries.GetLogsQuery
				query = new Application.LogsFeature.Queries.GetLogsQuery
				{
					Count = count,
				};

			var result =
				await Mediator.Send(query);

			return FluentResult(result: result);
		}
		#endregion /Get (Get Some Logs)
	}
}
