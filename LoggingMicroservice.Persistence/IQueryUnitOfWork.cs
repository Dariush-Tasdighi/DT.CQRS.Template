namespace LoggingMicroservice.Persistence
{
	public interface IQueryUnitOfWork : Dtx.Domain.IQueryUnitOfWork
	{
		public IQueryRepositories.ILogQueryRepository Logs { get; }
	}
}
