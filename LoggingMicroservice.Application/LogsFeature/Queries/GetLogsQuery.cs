namespace LoggingMicroservice.Application.LogsFeature.Queries
{
	public class GetLogsQuery : object,
		Dtx.Mediator.IRequest
		<System.Collections.Generic.IEnumerable<Domain.ViewModels.GetLogsQueryResponseViewModel>>
	{
		public GetLogsQuery() : base()
		{
		}

		public int? Count { get; set; }
	}
}
