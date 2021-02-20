namespace LoggingMicroservice.Application.LogsFeature.CommandHandlers
{
	public class CreateLogCommandHandler :
		object, MediatR.IRequestHandler<Commands.CreateLogCommand, FluentResults.Result<System.Guid>>
	{
		public CreateLogCommandHandler
			(Persistence.IUnitOfWork unitOfWork, AutoMapper.IMapper mapper) : base()
		{
			Mapper = mapper;
			UnitOfWork = unitOfWork;
		}

		protected AutoMapper.IMapper Mapper { get; }

		protected Persistence.IUnitOfWork UnitOfWork { get; }

		public
			async
			System.Threading.Tasks.Task
			<FluentResults.Result<System.Guid>>
			Handle(Commands.CreateLogCommand request, System.Threading.CancellationToken cancellationToken)
		{
			FluentResults.Result<System.Guid> result = null;

			try
			{
				// **************************************************
				result =
					await Utility.Validate<Commands.CreateLogCommand, System.Guid>
					(validator: new Validators.CreateLogCommandValidator(), command: request);

				if (result.IsFailed)
				{
					return result;
				}
				// **************************************************

				// **************************************************
				Domain.Models.Log log =
					Mapper.Map<Domain.Models.Log>(source: request);
				// **************************************************

				// **************************************************
				await UnitOfWork.Logs.InsertAsync(entity: log);
				// **************************************************

				// **************************************************
				result.WithValue(value: log.Id);

				string successInsert =
					string.Format(Resources.Messages.SuccessInsert, nameof(Domain.Models.Log));

				result.WithSuccess(successMessage: successInsert);
				// **************************************************
			}
			catch (System.Exception ex)
			{
				// Log

				result.WithError(errorMessage: ex.Message);
			}

			return result;
		}
	}
}
