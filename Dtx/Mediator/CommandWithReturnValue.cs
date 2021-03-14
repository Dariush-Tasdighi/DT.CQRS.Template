//namespace Dtx.Mediator
//{
//	public class CommandWithReturnValue<TValue> :
//		object, MediatR.IRequest<FluentResults.Result<TValue>>
//	{
//		public CommandWithReturnValue() : base()
//		{
//		}
//	}
//}

namespace Dtx.Mediator
{
	public interface ICommandWithReturnValue<TReturnValue> :
		MediatR.IRequest<FluentResults.Result<TReturnValue>>
	{
	}
}
