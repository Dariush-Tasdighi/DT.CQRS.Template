namespace Dtx.Mediator
{
	public class Query<TValue> :
		object, MediatR.IRequest<FluentResults.Result<TValue>>
	{
		public Query() : base()
		{
		}
	}
}
