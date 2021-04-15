namespace LoggingMicroservice.Application.Logs.Queries
{
	public class GetLogsQuery : object,
		Dtx.Mediator.IRequest
		<System.Collections.Generic.IEnumerable<Persistence.ViewModels.GetLogsQueryResponseViewModel>>
	{
		public GetLogsQuery() : base()
		{
		}

		public int? Count { get; set; }
	}
}
