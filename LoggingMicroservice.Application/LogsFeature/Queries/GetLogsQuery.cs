namespace LoggingMicroservice.Application.LogsFeature.Queries
{
	public class GetLogsQuery :
		Dtx.Mediator.CommandWithReturnValue
		<System.Collections.Generic.IEnumerable<Domain.ViewModels.GetLogsQueryResponseViewModel>>
	{
		public GetLogsQuery() : base()
		{
		}

		public int Count { get; set; }
	}
}
