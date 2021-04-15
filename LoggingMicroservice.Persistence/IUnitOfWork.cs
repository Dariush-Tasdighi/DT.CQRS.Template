namespace LoggingMicroservice.Persistence
{
	public interface IUnitOfWork : Dtx.Persistence.IUnitOfWork
	{
		public IRepositories.ILogRepository Logs { get; }
	}
}
