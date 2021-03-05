namespace LoggingMicroservice.Application.LogsFeature.CommandHandlers
{
	public class GetLogsQueryHandler :
		object,
		MediatR.IRequestHandler
		<Queries.GetLogsQuery, FluentResults.Result<System.Collections.Generic.IEnumerable<Domain.ViewModels.GetLogsQueryResponseViewModel>>>
	{
		public GetLogsQueryHandler
			(Dtx.Logging.ILogger<CreateLogCommandHandler> logger,
			AutoMapper.IMapper mapper,
			Persistence.IUnitOfWork unitOfWork) : base()
		{
			Logger = logger;
			Mapper = mapper;
			UnitOfWork = unitOfWork;
		}

		protected AutoMapper.IMapper Mapper { get; }

		protected Persistence.IUnitOfWork UnitOfWork { get; }

		protected Dtx.Logging.ILogger<CreateLogCommandHandler> Logger { get; }

		public
			async
			System.Threading.Tasks.Task
			<FluentResults.Result
				<System.Collections.Generic.IEnumerable
				<Domain.ViewModels.GetLogsQueryResponseViewModel>>>
			Handle(Queries.GetLogsQuery request, System.Threading.CancellationToken cancellationToken)
		{
			FluentResults.Result
				<System.Collections.Generic.IEnumerable
				< Domain.ViewModels.GetLogsQueryResponseViewModel >> result = null;

			try
			{
				// **************************************************
				var logs =
					await
					UnitOfWork.Logs
					.GetAllAsync();
					
				// **************************************************

				// **************************************************
				//result.WithValue(value: logs);

				string successInsert =
					string.Format(Resources.Messages.SuccessInsert, nameof(Domain.Models.Log));

				result.WithSuccess
					(successMessage: successInsert);
				// **************************************************
			}
			catch (System.Exception ex)
			{
				Logger.LogError
					(exception: ex, message: ex.Message);

				result.WithError
					(errorMessage: ex.Message);
			}

			return result;
		}
	}
}
