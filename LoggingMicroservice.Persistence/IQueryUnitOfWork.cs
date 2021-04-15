namespace LoggingMicroservice.Persistence
{
	public interface IQueryUnitOfWork : Dtx.Persistence.IQueryUnitOfWork
	{
		public Logs.Repositories.ILogQueryRepository Logs { get; }
	}
}
