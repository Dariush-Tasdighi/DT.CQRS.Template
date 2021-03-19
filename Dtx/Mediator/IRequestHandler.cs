namespace Dtx.Mediator
{
	public interface IRequestHandler<in TCommand, TReturnValue> :
		MediatR.IRequestHandler<TCommand, FluentResults.Result<TReturnValue>>
		where TCommand : MediatR.IRequest<FluentResults.Result<TReturnValue>>
	{
	}
}
