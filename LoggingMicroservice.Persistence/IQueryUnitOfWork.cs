namespace LoggingMicroservice.Persistence
{
	public interface IQueryUnitOfWork : Dtx.Domain.IQueryUnitOfWork
	{
		// **********
		Domain.IRepositories.ILogRepository Logs { get; }
		// **********
	}
}
