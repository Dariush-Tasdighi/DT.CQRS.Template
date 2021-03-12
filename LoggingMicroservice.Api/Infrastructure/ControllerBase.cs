namespace LoggingMicroservice.Api.Infrastructure
{
	public abstract class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
	{
		protected ControllerBase(MediatR.IMediator mediator) : base()
		{
			Mediator = mediator;
		}

		protected MediatR.IMediator Mediator { get; }

		protected Microsoft.AspNetCore.Mvc.IActionResult
			FluentResult<T>(FluentResults.Result<T> result)
		{
			if (result.IsSuccess)
			{
				return Ok(value: result);
			}
			else
			{
				return BadRequest(error: result.ToResult());
			}
		}
	}
}
