namespace LoggingMicroservice.Domain.ViewModels
{
	public class GetLogsQueryResponseViewModel : object
	{
		public GetLogsQueryResponseViewModel() : base()
		{
		}

		// **********
		public System.Guid Id { get; set; }
		// **********

		// **********
		public Enums.LogLevel Level { get; set; }
		// **********

		// **********
		public System.DateTime TimeStamp { get; set; }
		// **********



		// **********
		public string ApplicationName { get; set; }
		// **********

		// **********
		public string Namespace { get; set; }
		// **********

		// **********
		public string ClassName { get; set; }
		// **********

		// **********
		public string MethodName { get; set; }
		// **********



		// **********
		public string RemoteIP { get; set; }
		// **********

		// **********
		public string Username { get; set; }
		// **********

		// **********
		public string RequestPath { get; set; }
		// **********



		// **********
		public string Message { get; set; }
		// **********
	}
}
