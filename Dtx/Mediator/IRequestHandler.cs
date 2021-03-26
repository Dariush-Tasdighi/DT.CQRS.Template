namespace Dtx.Mediator
{
	public interface IRequestHandler<in TCommand> :
		MediatR.IRequestHandler<TCommand, FluentResults.Result>
		where TCommand : MediatR.IRequest<FluentResults.Result>
	{
	}

	public interface IRequestHandler<in TCommand, TReturnValue> :
		MediatR.IRequestHandler<TCommand, FluentResults.Result<TReturnValue>>
		where TCommand : MediatR.IRequest<FluentResults.Result<TReturnValue>>
	{
	}
}
