//namespace LoggingMicroservice.Application.LogsFeature.CommandHandlers
//{
//	public class CreateLogCommandHandler :
//		object, MediatR.IRequestHandler<Commands.CreateLogCommand, FluentResults.Result<System.Guid>>
//	{
//		public CreateLogCommandHandler
//			(Dtx.Logging.ILogger<CreateLogCommandHandler> logger,
//			AutoMapper.IMapper mapper,
//			Persistence.IUnitOfWork unitOfWork) : base()
//		{
//			Logger = logger;
//			Mapper = mapper;
//			UnitOfWork = unitOfWork;
//		}

//		protected AutoMapper.IMapper Mapper { get; }

//		protected Persistence.IUnitOfWork UnitOfWork { get; }

//		protected Dtx.Logging.ILogger<CreateLogCommandHandler> Logger { get; }

//		public
//			async
//			System.Threading.Tasks.Task
//			<FluentResults.Result<System.Guid>>
//			Handle(Commands.CreateLogCommand request, System.Threading.CancellationToken cancellationToken)
//		{
//			FluentResults.Result<System.Guid> result = null;

//			try
//			{
//				// **************************************************
//				result =
//					await Utility.Validate<Commands.CreateLogCommand, System.Guid>
//					(validator: new Commands.CreateLogCommandValidator(), command: request);

//				if (result.IsFailed)
//				{
//					return result;
//				}
//				// **************************************************

//				// **************************************************
//				Domain.Models.Log log =
//					Mapper.Map<Domain.Models.Log>(source: request);
//				// **************************************************

//				// **************************************************
//				await UnitOfWork.Logs.InsertAsync(entity: log);

//				await UnitOfWork.SaveAsync();
//				// **************************************************

//				// **************************************************
//				result.WithValue(value: log.Id);

//				string successInsert =
//					string.Format(Resources.Messages.SuccessInsert, nameof(Domain.Models.Log));

//				result.WithSuccess
//					(successMessage: successInsert);
//				// **************************************************
//			}
//			catch (System.Exception ex)
//			{
//				Logger.LogError
//					(exception: ex, message: ex.Message);

//				result.WithError
//					(errorMessage: ex.Message);
//			}

//			return result;
//		}
//	}
//}

namespace LoggingMicroservice.Application.LogsFeature.CommandHandlers
{
	public class CreateLogCommandHandler : object,
		Dtx.Mediator.IRequestHandler
		<Commands.CreateLogCommand, System.Guid>
	{
		public CreateLogCommandHandler
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
			<FluentResults.Result<System.Guid>>
			Handle(Commands.CreateLogCommand request,
			System.Threading.CancellationToken cancellationToken)
		{
			var result =
				new FluentResults.Result<System.Guid>();

			try
			{
				// **************************************************
				var log = Mapper.Map<Domain.Models.Log>(source: request);
				// **************************************************

				// **************************************************
				await UnitOfWork.Logs.InsertAsync(entity: log);

				await UnitOfWork.SaveAsync();
				// **************************************************

				// **************************************************
				result.WithValue(value: log.Id);

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
