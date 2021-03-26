namespace LoggingMicroservice.Persistence
{
	public interface IQueryUnitOfWork : Dtx.Domain.IQueryUnitOfWork
	{
		// **********
		Domain.IQueryRepositories.ILogQueryRepository Logs { get; }
		// **********
	}
}
