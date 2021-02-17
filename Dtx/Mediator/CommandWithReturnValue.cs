namespace Dtx.Mediator
{
	public class CommandWithReturnValue<TValue> :
		object, MediatR.IRequest<FluentResults.Result<TValue>>
	{
		public CommandWithReturnValue() : base()
		{
		}
	}
}
