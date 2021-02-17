namespace LoggingMicroservice.Api.Infrastructure
{
	public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
	{
		public ControllerBase(MediatR.IMediator mediator)
		{
			Mediator = mediator;
		}

		protected MediatR.IMediator Mediator { get; }
	}
}
