namespace LoggingMicroservice.Api.Infrastructure
{
	public abstract class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
	{
		protected ControllerBase(MediatR.IMediator mediator) : base()
		{
			Mediator = mediator;
		}

		protected MediatR.IMediator Mediator { get; }
	}
}
