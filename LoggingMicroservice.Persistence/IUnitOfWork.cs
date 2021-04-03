namespace LoggingMicroservice.Persistence
{
	public interface IUnitOfWork : Dtx.Domain.IUnitOfWork
	{
		public IRepositories.ILogRepository Logs { get; }
	}
}
