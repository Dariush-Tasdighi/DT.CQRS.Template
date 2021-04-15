namespace LoggingMicroservice.Persistence
{
	public interface IQueryUnitOfWork : Dtx.Persistence.IQueryUnitOfWork
	{
		public IQueryRepositories.ILogQueryRepository Logs { get; }
	}
}
