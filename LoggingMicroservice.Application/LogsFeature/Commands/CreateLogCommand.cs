namespace LoggingMicroservice.Application.LogsFeature.Commands
{
	public class CreateLogCommand : Dtx.Mediator.CommandWithReturnValue<System.Guid>
	{
		public CreateLogCommand() : base()
		{
		}

		// **********
		public Domain.Enums.LogLevel Level { get; set; }
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
		public string HttpReferrer { get; set; }
		// **********

		// **********
		public string Message { get; set; }
		// **********

		// **********
		public string Parameters { get; set; }
		// **********

		// **********
		public string Exceptions { get; set; }
		// **********
	}
}
