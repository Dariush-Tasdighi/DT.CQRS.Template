namespace LoggingMicroservice.Domain
{
	public interface IUnitOfWork : Dtx.Domain.IUnitOfWork
	{
		public IRepositories.ILogRepository Logs { get; set; }
	}
}
