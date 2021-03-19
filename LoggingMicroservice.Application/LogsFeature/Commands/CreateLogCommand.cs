namespace LoggingMicroservice.Application.LogsFeature.Commands
{
	//public class CreateLogCommand : MediatR.IRequest<System.Guid>

	//public class CreateLogCommand : MediatR.IRequest<FluentResults.Result<System.Guid>>

	public class CreateLogCommand :
		object, Dtx.Mediator.ICommandWithReturnValue<System.Guid>
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
