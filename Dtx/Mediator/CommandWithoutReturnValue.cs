//namespace Dtx.Mediator
//{
//	public class CommandWithoutReturnValue :
//		object, MediatR.IRequest<FluentResults.Result>
//	{
//		public CommandWithoutReturnValue() : base()
//		{
//		}
//	}
//}

namespace Dtx.Mediator
{
	public interface ICommandWithoutReturnValue : MediatR.IRequest<FluentResults.Result>
	{
	}
}
