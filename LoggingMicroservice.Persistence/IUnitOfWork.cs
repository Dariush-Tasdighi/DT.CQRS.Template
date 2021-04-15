namespace LoggingMicroservice.Persistence
{
	public interface IUnitOfWork : Dtx.Persistence.IUnitOfWork
	{
		public Logs.Repositories.ILogRepository Logs { get; }
	}
}
