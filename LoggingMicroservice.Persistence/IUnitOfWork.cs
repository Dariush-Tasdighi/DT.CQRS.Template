namespace LoggingMicroservice.Persistence
{
	public interface IUnitOfWork : Dtx.Domain.IUnitOfWork
	{
		// **********
		Domain.IRepositories.ILogRepository Logs { get; }
		// **********
	}
}
